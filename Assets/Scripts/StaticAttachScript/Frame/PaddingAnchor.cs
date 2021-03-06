﻿using System;
using System.Collections.Generic;
using UnityEngine;

public enum ANCHOR_MODE
{
	AM_NONE,                            // 无效值
	AM_PADDING_PARENT_SIDE,				// 停靠父节点的指定边界,并且大小不改变,0,1,2,3表示左上右下
	AM_NEAR_PARENT_SIDE,                // 将锚点设置到距离相对于父节点最近的边,并且各边界到父节点对应边界的距离固定不变
}

// 当mAnchorMode的值为AM_NEAR_SIDE时,要停靠的边界
public enum HORIZONTAL_PADDING_SIDE
{
	HPS_NONE = -1,
	HPS_LEFT,
	HPS_RIGHT,
	HPS_CENTER,
}

public enum VERTICAL_PADDING_SIDE
{
	VPS_NONE = -1,
	VPS_TOP,
	VPS_BOTTOM,
	VPS_CENTER,
}

[Serializable]
public struct ComplexPoint
{
	public float mRelative;
	public int mAbsolute;
	public void setRelative(float relative){mRelative = relative;}
	public void setAbsolute(float absolute){mAbsolute = (int)(absolute + 0.5f * Mathf.Sign(absolute));}
}

// 该组件所在的物体不能有旋转,否则会计算错误
public class PaddingAnchor : MonoBehaviour
{
	protected bool mDirty = true;
	protected Vector3[] mParentSides = new Vector3[4];
	// 用于避免GC而保存的变量
	protected Vector3[] mSides = new Vector3[4];
	protected Vector3[] mLocalCorners = new Vector3[4];
	// 用于保存属性的变量,需要为public权限
	public ANCHOR_MODE mAnchorMode;
	public HORIZONTAL_PADDING_SIDE mHorizontalNearSide;
	public VERTICAL_PADDING_SIDE mVerticalNearSide;
	public float mHorizontalPositionRelative;
	public int mHorizontalPositionAbsolute;
	public float mVerticalPositionRelative;
	public int mVerticalPositionAbsolute;
	public bool mRelativeDistance;
	public bool mAdjustFont = true;
	// 左上右下,横向中心,纵向中心的顺序
	// 边相对于父节点对应边的距离,Relative是相对于宽或者高的一半,范围0-1,从0到1是对应从中心到各边,Absolute是Relative计算完以后的偏移量,带正负
	public ComplexPoint[] mDistanceToBoard = new ComplexPoint[4] { new ComplexPoint(), new ComplexPoint(), new ComplexPoint(), new ComplexPoint() };
	public ComplexPoint[] mAnchorPoint = new ComplexPoint[4] { new ComplexPoint(), new ComplexPoint(), new ComplexPoint(), new ComplexPoint() };
	public void setAnchorModeInEditor(ANCHOR_MODE mode)
	{
		mAnchorMode = mode;
		setAnchorMode(mAnchorMode);
	}
	public void setHorizontalNearSideInEditor(HORIZONTAL_PADDING_SIDE side)
	{
		mHorizontalNearSide = side;
		setAnchorMode(mAnchorMode);
	}
	public void setVerticalNearSideInEditor(VERTICAL_PADDING_SIDE side)
	{
		mVerticalNearSide = side;
		setAnchorMode(mAnchorMode);
	}
	public void setRelativeDistanceInEditor(bool relativeDistance)
	{
		mRelativeDistance = relativeDistance;
		setAnchorMode(mAnchorMode);
	}
	public void setAnchorMode(ANCHOR_MODE mode)
	{
		mAnchorMode = mode;
		if (mAnchorMode == ANCHOR_MODE.AM_PADDING_PARENT_SIDE)
		{
			setToPaddingParentSide(mHorizontalNearSide, mVerticalNearSide, mRelativeDistance);
		}
		else if (mAnchorMode == ANCHOR_MODE.AM_NEAR_PARENT_SIDE)
		{
			setToNearParentSides(mRelativeDistance);
		}
	}
	public void updateRect(bool force = false)
	{
		if (!force && !mDirty)
		{
			return;
		}
		// 如果窗口带缩放,则可能适配不正确
		if(!ReflectionUtility.isVectorZero(transform.localScale - Vector3.one))
		{
			ReflectionUtility.logWarning("transform's scale is not 1, may not adapt correctely, " + transform.name + ", scale:" + ReflectionUtility.vector3ToString(transform.localScale, 6));
		}
		bool ngui = ReflectionUtility.isNGUI(gameObject);
		mDirty = false;
		Vector2 newSize = Vector2.zero;
		GameObject parent = null;
		Vector2 parentSize = Vector2.zero;
		if (ngui)
		{
#if USE_NGUI
			newSize = ReflectionUtility.getNGUIRectSize(GetComponent<UIWidget>());
			UIRect parentRect = ReflectionUtility.findNGUIParentRect(gameObject);
			if (parentRect != null)
			{
				parent = parentRect.gameObject;
				parentSize = ReflectionUtility.getNGUIRectSize(parentRect);
			}
			// NGUI时如果没有父节点,则只能使用绝对大小
			else
			{
				newSize.x = mAnchorPoint[2].mAbsolute - mAnchorPoint[0].mAbsolute;
				newSize.y = mAnchorPoint[1].mAbsolute - mAnchorPoint[3].mAbsolute;
				parentSize = ReflectionUtility.getRootSize(true);
			}
#endif
		}
		else
		{
			newSize = GetComponent<RectTransform>().rect.size;
			parent = transform.parent.gameObject;
			parentSize = parent.GetComponent<RectTransform>().rect.size;
		}
		Vector3 pos = transform.localPosition;
		if (parent != null)
		{
			ReflectionUtility.getParentSides(parent, mParentSides);
			// 仅仅停靠到父节点的某条边,只需要根据当前大小和父节点大小计算位置
			if (mAnchorMode == ANCHOR_MODE.AM_PADDING_PARENT_SIDE)
			{
				// 横向位置
				if(mHorizontalNearSide == HORIZONTAL_PADDING_SIDE.HPS_LEFT)
				{
					pos.x = mDistanceToBoard[0].mRelative * mParentSides[0].x + mDistanceToBoard[0].mAbsolute + newSize.x * 0.5f;
				}
				else if(mHorizontalNearSide == HORIZONTAL_PADDING_SIDE.HPS_RIGHT)
				{
					pos.x = mDistanceToBoard[2].mRelative * mParentSides[2].x + mDistanceToBoard[2].mAbsolute - newSize.x * 0.5f;
				}
				else if(mHorizontalNearSide == HORIZONTAL_PADDING_SIDE.HPS_CENTER)
				{
					pos.x = mHorizontalPositionRelative * parentSize.x * 0.5f + mHorizontalPositionAbsolute;
				}
				// 纵向位置
				if (mVerticalNearSide == VERTICAL_PADDING_SIDE.VPS_TOP)
				{
					pos.y = mDistanceToBoard[1].mRelative * mParentSides[1].y + mDistanceToBoard[1].mAbsolute - newSize.y * 0.5f;
				}
				else if (mVerticalNearSide == VERTICAL_PADDING_SIDE.VPS_BOTTOM)
				{
					pos.y = mDistanceToBoard[3].mRelative * mParentSides[3].y + mDistanceToBoard[3].mAbsolute + newSize.y * 0.5f;
				}
				else if (mVerticalNearSide == VERTICAL_PADDING_SIDE.VPS_CENTER)
				{
					pos.y = mVerticalPositionRelative * parentSize.y * 0.5f + mVerticalPositionAbsolute;
				}
			}
			// 根据锚点和父节点大小计算各条边的值
			else if(mAnchorMode != ANCHOR_MODE.AM_NONE)
			{
				float thisLeft = mAnchorPoint[0].mRelative * mParentSides[0].x + mAnchorPoint[0].mAbsolute;
				float thisRight = mAnchorPoint[2].mRelative * mParentSides[2].x + mAnchorPoint[2].mAbsolute;
				float thisTop = mAnchorPoint[1].mRelative * mParentSides[1].y + mAnchorPoint[1].mAbsolute;
				float thisBottom = mAnchorPoint[3].mRelative * mParentSides[3].y + mAnchorPoint[3].mAbsolute;
				newSize.x = thisRight - thisLeft;
				newSize.y = thisTop - thisBottom;
				pos.x = (thisRight + thisLeft) * 0.5f;
				pos.y = (thisTop + thisBottom) * 0.5f;
			}
		}
		if (newSize.x < 0)
		{
			ReflectionUtility.logError("width:" + newSize.x + " is not valid, consider to modify the PaddingAnchor! " + gameObject.name + ", parent:" + gameObject.transform.parent.name);
		}
		if (newSize.y < 0)
		{
			ReflectionUtility.logError("height:" + newSize.y + " is not valid, consider to modify the PaddingAnchor! " + gameObject.name + ", parent:" + gameObject.transform.parent.name);
		}
		if (ngui)
		{
#if USE_NGUI
			ReflectionUtility.setNGUIWidgetSize(GetComponent<UIWidget>(), newSize);
#endif
		}
		else
		{
			ReflectionUtility.setUGUIRectSize(GetComponent<RectTransform>(), newSize, mAdjustFont);
		}
		transform.localPosition = ReflectionUtility.round(pos);
	}
	//------------------------------------------------------------------------------------------------------------------------------------------------
	// 将锚点设置到距离相对于父节点最近的边,并且各边界到父节点对应边界的距离固定不变
	protected void setToNearParentSides(bool relative)
	{
		GameObject parent = null;
		if (ReflectionUtility.isNGUI(gameObject))
		{
			#if USE_NGUI
			UIRect parentRect = ReflectionUtility.findNGUIParentRect(gameObject);
			if (parentRect != null)
			{
				parent = parentRect.gameObject;
			}
			else
			{
				Vector3[] sides = getSides(null);
				for (int i = 0; i < 4; ++i)
				{
					mAnchorPoint[i].setRelative(0.0f);
					if (i == 0 || i == 2)
					{
						mAnchorPoint[i].setAbsolute(ReflectionUtility.getLength(sides[i]));
					}
					else if (i == 1 || i == 3)
					{
						mAnchorPoint[i].setAbsolute(ReflectionUtility.getLength(sides[i]));
					}
				}
			}
#endif
		}
		else
		{
			parent = transform.parent.gameObject;
		}
		if(parent != null)
		{
			Vector3[] sides = getSides(parent);
			ReflectionUtility.getParentSides(parent, mParentSides);
			for (int i = 0; i < 4; ++i)
			{
				if (i == 0 || i == 2)
				{
					float relativeLeft = sides[i].x - mParentSides[0].x;
					float relativeCenter = sides[i].x;
					float relativeRight = sides[i].x - mParentSides[2].x;
					float disToLeft = Mathf.Abs(relativeLeft);
					float disToCenter = Mathf.Abs(relativeCenter);
					float disToRight = Mathf.Abs(relativeRight);
					if (relative)
					{
						mAnchorPoint[i].setRelative(sides[i].x / mParentSides[i].x);
						mAnchorPoint[i].setAbsolute(0.0f);
					}
					else
					{
						// 靠近左边
						if (disToLeft < disToCenter && disToLeft < disToRight)
						{
							mAnchorPoint[i].setRelative(Mathf.Sign(sides[i].x) * Mathf.Sign(mParentSides[i].x));
							mAnchorPoint[i].setAbsolute(relativeLeft);
						}
						// 靠近右边
						else if (disToRight < disToLeft && disToRight < disToCenter)
						{
							mAnchorPoint[i].setRelative(Mathf.Sign(sides[i].x) * Mathf.Sign(mParentSides[i].x));
							mAnchorPoint[i].setAbsolute(relativeRight);
						}
						// 靠近中心
						else
						{
							mAnchorPoint[i].setRelative(0.0f);
							mAnchorPoint[i].setAbsolute(relativeCenter);
						}
					}
				}
				else if (i == 1 || i == 3)
				{
					float relativeTop = sides[i].y - mParentSides[1].y;
					float relativeCenter = sides[i].y;
					float relativeBottom = sides[i].y - mParentSides[3].y;
					float disToTop = Mathf.Abs(relativeTop);
					float disToCenter = Mathf.Abs(relativeCenter);
					float disToBottom = Mathf.Abs(relativeBottom);
					if(relative)
					{
						mAnchorPoint[i].setRelative(sides[i].y / mParentSides[i].y);
						mAnchorPoint[i].setAbsolute(0.0f);
					}
					else
					{
						// 靠近顶部
						if (disToTop < disToCenter && disToTop < disToBottom)
						{
							mAnchorPoint[i].setRelative(Mathf.Sign(sides[i].y) * Mathf.Sign(mParentSides[i].y));
							mAnchorPoint[i].setAbsolute(relativeTop);
						}
						// 靠近底部
						else if (disToBottom < disToTop && disToBottom < disToCenter)
						{
							mAnchorPoint[i].setRelative(Mathf.Sign(sides[i].y) * Mathf.Sign(mParentSides[i].y));
							mAnchorPoint[i].setAbsolute(relativeBottom);
						}
						// 靠近中心
						else
						{
							mAnchorPoint[i].setRelative(0.0f);
							mAnchorPoint[i].setAbsolute(relativeCenter);
						}
					}
				}
			}
		}
	}
	// 停靠父节点的指定边界,并且大小不改变
	protected void setToPaddingParentSide(HORIZONTAL_PADDING_SIDE horizontalSide, VERTICAL_PADDING_SIDE verticalSide, bool relativeDistance)
	{
		Vector3[] sides = null;
		Vector2 pos = transform.localPosition;
		Vector2 parentSize = Vector2.zero;
		GameObject parent = null;
		if(ReflectionUtility.isNGUI(gameObject))
		{
#if USE_NGUI
			UIRect parentRect = ReflectionUtility.findNGUIParentRect(gameObject);
			if (parentRect != null)
			{
				parent = parentRect.gameObject;
				parentSize = ReflectionUtility.getNGUIRectSize(parentRect);
			}
			else
			{
				sides = getSides(null);
				for (int i = 0; i < 4; ++i)
				{
					mAnchorPoint[i].setRelative(0.0f);
					mAnchorPoint[i].setAbsolute((i == 0 || i == 2) ? sides[i].x : sides[i].y);
				}
				parentSize.x = Mathf.Abs(sides[0].x) * 2.0f;
				parentSize.y = Mathf.Abs(sides[1].y) * 2.0f;
			}
#endif
		}
		else
		{
			parent = transform.parent.gameObject;
			parentSize = parent.GetComponent<RectTransform>().rect.size;
		}
		if (parent != null)
		{
			sides = getSides(parent);
			ReflectionUtility.getParentSides(parent, mParentSides);
		}
		int count = mDistanceToBoard.Length;
		for(int i = 0; i < count; ++i)
		{
			mDistanceToBoard[i].setRelative(0.0f);
			mDistanceToBoard[i].setAbsolute(0.0f);
		}
		// 相对于左右边界
		if (horizontalSide == HORIZONTAL_PADDING_SIDE.HPS_LEFT)
		{
			if(relativeDistance)
			{
				mDistanceToBoard[0].mRelative = Mathf.Abs(sides[0].x / mParentSides[0].x);
				mDistanceToBoard[0].setAbsolute(0.0f);
			}
			else
			{
				mDistanceToBoard[0].mRelative = 1.0f;
				mDistanceToBoard[0].setAbsolute(sides[0].x - mParentSides[0].x);
			}
		}
		else if(horizontalSide == HORIZONTAL_PADDING_SIDE.HPS_RIGHT)
		{
			if (relativeDistance)
			{
				mDistanceToBoard[2].mRelative = Mathf.Abs(sides[2].x / mParentSides[2].x);
				mDistanceToBoard[2].setAbsolute(0.0f);
			}
			else
			{
				mDistanceToBoard[2].mRelative = 1.0f;
				mDistanceToBoard[2].setAbsolute(sides[2].x - mParentSides[2].x);
			}
		}
		else if(horizontalSide == HORIZONTAL_PADDING_SIDE.HPS_CENTER)
		{
			if (relativeDistance)
			{
				mHorizontalPositionRelative = pos.x / (parentSize.x * 0.5f);
				mHorizontalPositionAbsolute = 0;
			}
			else
			{
				mHorizontalPositionRelative = 0.0f;
				mHorizontalPositionAbsolute = (int)(pos.x + 0.5f * Mathf.Sign(pos.x));
			}
		}
		if(verticalSide == VERTICAL_PADDING_SIDE.VPS_TOP)
		{
			if (relativeDistance)
			{
				mDistanceToBoard[1].mRelative = Mathf.Abs(sides[1].y / mParentSides[1].y);
				mDistanceToBoard[1].setAbsolute(0.0f);
			}
			else
			{
				mDistanceToBoard[1].mRelative = 1.0f;
				mDistanceToBoard[1].setAbsolute(sides[1].y - mParentSides[1].y);
			}
		}
		else if(verticalSide == VERTICAL_PADDING_SIDE.VPS_BOTTOM)
		{
			if (relativeDistance)
			{
				mDistanceToBoard[3].mRelative = Mathf.Abs(sides[3].y / mParentSides[3].y);
				mDistanceToBoard[3].setAbsolute(0.0f);
			}
			else
			{
				mDistanceToBoard[3].mRelative = 1.0f;
				mDistanceToBoard[3].setAbsolute(sides[3].y - mParentSides[3].y);
			}
		}
		else if (verticalSide == VERTICAL_PADDING_SIDE.VPS_CENTER)
		{
			if (relativeDistance)
			{
				mVerticalPositionRelative = pos.y / (parentSize.y * 0.5f);
				mVerticalPositionAbsolute = 0;
			}
			else
			{
				mVerticalPositionRelative = 0.0f;
				mVerticalPositionAbsolute = (int)(pos.y + 0.5f * Mathf.Sign(pos.y));
			}
		}
		for (int i = 0; i < 4; ++i)
		{
			mAnchorPoint[i].setRelative(0.0f);
			mAnchorPoint[i].setAbsolute(0.0f);
		}
	}
	// 本地坐标系下的的各条边
	protected Vector3[] getSides(GameObject parent)
	{
		generateLocalCorners(parent);
		ReflectionUtility.cornerToSide(mLocalCorners, mSides);
		return mSides;
	}
	protected void generateLocalCorners(GameObject parent, bool includeRotation = false)
	{
		if (ReflectionUtility.isNGUI(gameObject))
		{
#if USE_NGUI
			Vector3[] worldCorners = GetComponent<UIRect>().worldCorners;
			for (int i = 0; i < 4; ++i)
			{
				mLocalCorners[i] = parent != null ? parent.transform.InverseTransformPoint(worldCorners[i]) : worldCorners[i];
			}
#endif
		}
		else
		{
			RectTransform rectTransform = GetComponent<RectTransform>();
			// 去除旋转
			Quaternion lastQuat = rectTransform.rotation;
			if (!includeRotation)
			{
				rectTransform.rotation = Quaternion.identity;
			}
			Vector2 size = rectTransform.rect.size;
			mLocalCorners[0] = new Vector3(-size.x * 0.5f, -size.y * 0.5f);
			mLocalCorners[1] = new Vector3(-size.x * 0.5f, size.y * 0.5f);
			mLocalCorners[2] = new Vector3(size.x * 0.5f, size.y * 0.5f);
			mLocalCorners[3] = new Vector3(size.x * 0.5f, -size.y * 0.5f);
			for (int i = 0; i < 4; ++i)
			{
				Vector3 worldCorner = ReflectionUtility.localToWorld(rectTransform, mLocalCorners[i]);
				mLocalCorners[i] = ReflectionUtility.worldToLocal(parent.transform, worldCorner);
			}
			if (!includeRotation)
			{
				rectTransform.rotation = lastQuat;
			}
		}
	}
}