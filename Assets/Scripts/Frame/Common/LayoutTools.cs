﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

// LayoutTools
public class LT : GameBase
{
	//------------------------------------------------------------------------------------------------------------------------------------
	// 布局
	#region 布局
	public static void LOAD_NGUI(LAYOUT type, int renderOrder, bool visible, bool immediately, string param)
	{
		CommandLayoutManagerLoadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mVisible = visible;
		cmd.mRenderOrder = renderOrder;
		cmd.mAsync = false;
		cmd.mImmediatelyShow = immediately;
		cmd.mParam = param;
		cmd.mIsNGUI = true;
		cmd.mIsScene = false;
		pushCommand(cmd, mLayoutManager);
	}
	public static void LOAD_NGUI_ASYNC(LAYOUT type, int renderOrder, LayoutAsyncDone callback)
	{
		CommandLayoutManagerLoadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mRenderOrder = renderOrder;
		cmd.mAsync = true;
		cmd.mCallback = callback;
		cmd.mIsNGUI = true;
		cmd.mIsScene = false;
		pushCommand(cmd, mLayoutManager);
	}
	public static void LOAD_UGUI(LAYOUT type, int renderOrder, bool visible, bool immediately, string param)
	{
		CommandLayoutManagerLoadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mVisible = visible;
		cmd.mRenderOrder = renderOrder;
		cmd.mAsync = false;
		cmd.mImmediatelyShow = immediately;
		cmd.mParam = param;
		cmd.mIsNGUI = false;
		cmd.mIsScene = false;
		pushCommand(cmd, mLayoutManager);
	}
	public static void LOAD_UGUI_SCENE(LAYOUT type, int renderOrder, bool visible, bool immediately, string param)
	{
		CommandLayoutManagerLoadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mVisible = visible;
		cmd.mAsync = false;
		cmd.mImmediatelyShow = immediately;
		cmd.mParam = param;
		cmd.mIsNGUI = false;
		cmd.mIsScene = true;
		cmd.mRenderOrder = renderOrder;
		pushCommand(cmd, mLayoutManager);
	}
	public static void LOAD_NGUI_SCENE(LAYOUT type, int renderOrder, bool visible, bool immediately, string param)
	{
		CommandLayoutManagerLoadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mVisible = visible;
		cmd.mRenderOrder = renderOrder;
		cmd.mAsync = false;
		cmd.mImmediatelyShow = immediately;
		cmd.mParam = param;
		cmd.mIsNGUI = true;
		cmd.mIsScene = true;
		pushCommand(cmd, mLayoutManager);
	}
	public static void LOAD_NGUI_SCENE_ASYNC(LAYOUT type, int renderOrder, LayoutAsyncDone callback)
	{
		CommandLayoutManagerLoadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mRenderOrder = renderOrder;
		cmd.mAsync = true;
		cmd.mCallback = callback;
		cmd.mIsNGUI = true;
		cmd.mIsScene = true;
		pushCommand(cmd, mLayoutManager);
	}
	public static void LOAD_UGUI_ASYNC(LAYOUT type, int renderOrder, LayoutAsyncDone callback)
	{
		CommandLayoutManagerLoadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mRenderOrder = renderOrder;
		cmd.mAsync = true;
		cmd.mCallback = callback;
		cmd.mIsNGUI = false;
		cmd.mIsScene = false;
		pushCommand(cmd, mLayoutManager);
	}
	public static void UNLOAD_LAYOUT(LAYOUT type)
	{
		// 需要首先强制隐藏布局
		HIDE_LAYOUT_FORCE(type);
		CommandLayoutManagerUnloadLayout cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		pushCommand(cmd, mLayoutManager);
	}
	public static void UNLOAD_LAYOUT_DELAY(LAYOUT type, float delayTime)
	{
		CommandLayoutManagerUnloadLayout cmd = newCmd(out cmd, true, true);
		cmd.mLayoutType = type;
		pushDelayCommand(cmd, mLayoutManager, delayTime);
	}
	public static void LOAD_NGUI_HIDE(LAYOUT type, int renderOrder)
	{
		LOAD_NGUI(type, renderOrder, false, false, null);
	}
	public static void LOAD_NGUI_SHOW(LAYOUT type, int renderOrder)
	{
		LOAD_NGUI(type, renderOrder, true, false, null);
	}
	public static void LOAD_NGUI_SHOW(LAYOUT type, int renderOrder, bool immediately, string param = null)
	{
		LOAD_NGUI(type, renderOrder, true, immediately, param);
	}
	public static void LOAD_NGUI_SCENE_HIDE(LAYOUT type, int renderOrder)
	{
		LOAD_NGUI_SCENE(type, renderOrder, false, false, null);
	}
	public static void LOAD_NGUI_SCENE_SHOW(LAYOUT type, int renderOrder)
	{
		LOAD_NGUI_SCENE(type, renderOrder, true, false, null);
	}
	public static void LOAD_UGUI_SCENE_HIDE(LAYOUT type, int renderOrder)
	{
		LOAD_UGUI_SCENE(type, renderOrder, false, false, null);
	}
	public static void LOAD_UGUI_SCENE_SHOW(LAYOUT type, int renderOrder)
	{
		LOAD_UGUI_SCENE(type, renderOrder, true, false, null);
	}
	public static void LOAD_UGUI_HIDE(LAYOUT type, int renderOrder)
	{
		LOAD_UGUI(type, renderOrder, false, false, null);
	}
	public static void LOAD_UGUI_SHOW(LAYOUT type, int renderOrder)
	{
		LOAD_UGUI(type, renderOrder, true, false, EMPTY_STRING);
	}
	public static void LOAD_UGUI_SHOW(LAYOUT type, int renderOrder, bool immediately, string param = null)
	{
		LOAD_UGUI(type, renderOrder, true, immediately, param);
	}
	public static void HIDE_LAYOUT(LAYOUT type, bool immediately = false, string param = null)
	{
		VISIBLE_LAYOUT(type, false, immediately, param);
	}
	public static void HIDE_LAYOUT_FORCE(LAYOUT type)
	{
		VISIBLE_LAYOUT_FORCE(type, false);
	}
	public static void SHOW_LAYOUT(LAYOUT type, bool immediately = false, string param = null)
	{
		VISIBLE_LAYOUT(type, true, immediately, param);
	}
	public static void SHOW_LAYOUT_FORCE(LAYOUT type)
	{
		VISIBLE_LAYOUT_FORCE(type, true);
	}
	public static void VISIBLE_LAYOUT(LAYOUT type, bool visible, bool immediately = false, string param = null)
	{
		CommandLayoutManagerLayoutVisible cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mForce = false;
		cmd.mVisibility = visible;
		cmd.mImmediately = immediately;
		cmd.mParam = param;
		pushCommand(cmd, mLayoutManager);
	}
	public static void VISIBLE_LAYOUT_FORCE(LAYOUT type, bool visible)
	{
		CommandLayoutManagerLayoutVisible cmd = newCmd(out cmd, true, false);
		cmd.mLayoutType = type;
		cmd.mForce = true;
		cmd.mVisibility = visible;
		cmd.mImmediately = false;
		pushCommand(cmd, mLayoutManager);
	}
	public static CommandLayoutManagerLayoutVisible HIDE_LAYOUT_DELAY(SceneProcedure procedure, float delayTime, LAYOUT type, bool immediately = false, string param = null)
	{
		return VISIBLE_LAYOUT_DELAY(procedure, delayTime, type, false, immediately, param);
	}
	public static CommandLayoutManagerLayoutVisible HIDE_LAYOUT_DELAY_FORCE(float delayTime, LAYOUT type)
	{
		return VISIBLE_LAYOUT_DELAY_FORCE(delayTime, type, false);
	}
	public static CommandLayoutManagerLayoutVisible SHOW_LAYOUT_DELAY(SceneProcedure procedure, float delayTime, LAYOUT type, bool immediately = false, string param = null)
	{
		return VISIBLE_LAYOUT_DELAY(procedure, delayTime, type, true, immediately, param);
	}
	public static CommandLayoutManagerLayoutVisible SHOW_LAYOUT_DELAY_EX(SceneProcedure procedure, float delayTime, LAYOUT type, CommandCallback start, bool immediately = false, string param = null)
	{
		return VISIBLE_LAYOUT_DELAY_EX(procedure, delayTime, type, true, start, immediately, param);
	}
	public static CommandLayoutManagerLayoutVisible SHOW_LAYOUT_DELAY_FORCE(float delayTime, LAYOUT type)
	{
		return VISIBLE_LAYOUT_DELAY_FORCE(delayTime, type, true);
	}
	public static CommandLayoutManagerLayoutVisible VISIBLE_LAYOUT_DELAY(SceneProcedure procedure, float delayTime, LAYOUT type, bool visible, bool immediately = false, string param = null)
	{
		CommandLayoutManagerLayoutVisible cmd = newCmd(out cmd, true, true);
		cmd.mLayoutType = type;
		cmd.mForce = false;
		cmd.mVisibility = visible;
		cmd.mImmediately = immediately;
		cmd.mParam = param;
		pushDelayCommand(cmd, mLayoutManager, delayTime);
		procedure?.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandLayoutManagerLayoutVisible VISIBLE_LAYOUT_DELAY_EX(SceneProcedure procedure, float delayTime, LAYOUT type, bool visible, CommandCallback start, bool immediately = false, string param = null)
	{
		CommandLayoutManagerLayoutVisible cmd = newCmd(out cmd, true, true);
		cmd.mLayoutType = type;
		cmd.mForce = false;
		cmd.mVisibility = visible;
		cmd.mImmediately = immediately;
		cmd.mParam = param;
		cmd.addStartCommandCallback(start);
		pushDelayCommand(cmd, mLayoutManager, delayTime);
		procedure?.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandLayoutManagerLayoutVisible VISIBLE_LAYOUT_DELAY_FORCE(float delayTime, LAYOUT type, bool visible)
	{
		CommandLayoutManagerLayoutVisible cmd = newCmd(out cmd, true, true);
		cmd.mLayoutType = type;
		cmd.mForce = true;
		cmd.mVisibility = visible;
		cmd.mImmediately = false;
		pushDelayCommand(cmd, mLayoutManager, delayTime);
		return cmd;
	}
	#endregion
	#region 窗口的显示和隐藏
	public static void ACTIVE(txUIObject obj, bool active = true)
	{
		obj?.setActive(active);
	}
	public static CommandWindowActive ACTIVE_DELAY(LayoutScript script, txUIObject obj, bool active)
	{
		return ACTIVE_DELAY_EX(script, obj, active, 0.001f, null);
	}
	public static CommandWindowActive ACTIVE_DELAY(LayoutScript script, txUIObject obj, bool active, float delayTime)
	{
		return ACTIVE_DELAY_EX(script, obj, active, delayTime, null);
	}
	public static CommandWindowActive ACTIVE_DELAY_EX(LayoutScript script, txUIObject obj, bool active, float dealyTime, CommandCallback startCallback)
	{
		CommandWindowActive cmd = newCmd(out cmd, false, true);
		cmd.mActive = active;
		cmd.addStartCommandCallback(startCallback);
		pushDelayCommand(cmd, obj, dealyTime);
		script?.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 旋转
	#region 在普通更新中用关键帧旋转物体
	public static void ROTATE_FIXED(Transformable obj, bool lockRotation = true)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableRotateFixed cmd = newCmd(out cmd, false, false);
		cmd.mActive = lockRotation;
		pushCommand(cmd, obj);
	}
	public static void ROTATE_FIXED(Transformable obj, Vector3 rot, bool lockRotation = true)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableRotateFixed cmd = newCmd(out cmd, false, false);
		cmd.mActive = lockRotation;
		cmd.mFixedEuler = rot;
		pushCommand(cmd, obj);
	}
	public static void ROTATE(Transformable obj)
	{
		ROTATE(obj, Vector3.zero);
	}
	public static void ROTATE(Transformable obj, Vector3 rotation)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableRotate cmd = newCmd(out cmd, false, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartRotation = rotation;
		cmd.mTargetRotation = rotation;
		pushCommand(cmd, obj);
	}
	public static void ROTATE(Transformable obj, Vector3 start, Vector3 target, float time)
	{
		ROTATE_EX(obj, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f, null, null);
	}
	public static void ROTATE(Transformable obj, string keyframe, Vector3 start, Vector3 target, float onceLength)
	{
		ROTATE_EX(obj, keyframe, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void ROTATE(Transformable obj, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset)
	{
		ROTATE_EX(obj, keyframe, start, target, onceLength, loop, offset, null, null);
	}
	public static void ROTATE_EX(Transformable obj, Vector3 start, Vector3 target, float time, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ROTATE_EX(obj, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f, doingCallback, doneCallback);
	}
	public static void ROTATE_EX(Transformable obj, Vector3 start, Vector3 target, float time, KeyFrameCallback doneCallback)
	{
		ROTATE_EX(obj, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f, null, doneCallback);
	}
	public static void ROTATE_EX(Transformable obj, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		if (isEmpty(keyframe) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用void ROTATE(Transformable obj, Vector3 rotation)");
			return;
		}
		CommandTransformableRotate cmd = newCmd(out cmd, false, false);
		cmd.mName = keyframe;
		cmd.mOnceLength = onceLength;
		cmd.mStartRotation = start;
		cmd.mTargetRotation = target;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableRotate ROTATE_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 rotation)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableRotate cmd = newCmd(out cmd, false, true);
		cmd.mOnceLength = 0.0f;
		cmd.mStartRotation = rotation;
		cmd.mTargetRotation = rotation;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableRotate ROTATE_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float time)
	{
		return ROTATE_DELAY(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f);
	}
	public static CommandTransformableRotate ROTATE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength)
	{
		return ROTATE_DELAY(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f);
	}
	public static CommandTransformableRotate ROTATE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop)
	{
		return ROTATE_DELAY(script, obj, delayTime, keyframe, start, target, onceLength, loop, 0.0f);
	}
	public static CommandTransformableRotate ROTATE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset)
	{
		if (obj == null)
		{
			return null;
		}
		if (isEmpty(keyframe) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用CommandTransformableRotate ROTATE_DELAY(Transformable obj, float delayTime, Vector3 rotation)");
			return null;
		}
		CommandTransformableRotate cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mOnceLength = onceLength;
		cmd.mStartRotation = start;
		cmd.mTargetRotation = target;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static void ROTATE_SPEED(Transformable obj)
	{
		ROTATE_SPEED(obj, Vector3.zero, Vector3.zero, Vector3.zero);
	}
	public static void ROTATE_SPEED(Transformable obj, Vector3 speed)
	{
		ROTATE_SPEED(obj, speed, Vector3.zero, Vector3.zero);
	}
	public static void ROTATE_SPEED(Transformable obj, Vector3 speed, Vector3 startAngle)
	{
		ROTATE_SPEED(obj, speed, startAngle, Vector3.zero);
	}
	public static void ROTATE_SPEED(Transformable obj, Vector3 speed, Vector3 startAngle, Vector3 rotateAccelerationValue)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableRotateSpeed cmd = newCmd(out cmd, false, false);
		cmd.mRotateSpeed = speed;
		cmd.mStartAngle = startAngle;
		cmd.mRotateAcceleration = rotateAccelerationValue;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableRotateSpeed ROTATE_SPEED_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 speed)
	{
		return ROTATE_SPEED_DELAY(script, obj, delayTime, speed, Vector3.zero, Vector3.zero);
	}
	public static CommandTransformableRotateSpeed ROTATE_SPEED_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 speed, Vector3 startAngle)
	{
		return ROTATE_SPEED_DELAY(script, obj, delayTime, speed, startAngle, Vector3.zero);
	}
	public static CommandTransformableRotateSpeed ROTATE_SPEED_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 speed, Vector3 startAngle, Vector3 rotateAccelerationValue)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableRotateSpeed cmd = newCmd(out cmd, false, true);
		cmd.mRotateSpeed = speed;
		cmd.mStartAngle = startAngle;
		cmd.mRotateAcceleration = rotateAccelerationValue;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	#region 在物理更新中用关键帧旋转物体
	public static void ROTATE_FIXED_PHY(Transformable obj, bool lockRotation = true)
	{
		CommandTransformableRotateFixedPhysics cmd = newCmd(out cmd, false, false);
		cmd.mActive = lockRotation;
		pushCommand(cmd, obj);
	}
	public static void ROTATE_FIXED_PHY(Transformable obj, Vector3 rot, bool lockRotation = true)
	{
		CommandTransformableRotateFixedPhysics cmd = newCmd(out cmd, false, false);
		cmd.mActive = lockRotation;
		cmd.mFixedEuler = rot;
		pushCommand(cmd, obj);
	}
	public static void ROTATE_PHY(Transformable obj, Vector3 rotation)
	{
		CommandTransformableRotatePhysics cmd = newCmd(out cmd, false, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartRotation = rotation;
		cmd.mTargetRotation = rotation;
		pushCommand(cmd, obj);
	}
	public static void ROTATE_PHY(Transformable obj, Vector3 start, Vector3 target, float time)
	{
		ROTATE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f, null, null);
	}
	public static void ROTATE_PHY(Transformable obj, string keyframe, Vector3 start, Vector3 target, float onceLength)
	{
		ROTATE_PHY_EX(obj, keyframe, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void ROTATE_PHY(Transformable obj, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset)
	{
		ROTATE_PHY_EX(obj, keyframe, start, target, onceLength, loop, offset, null, null);
	}
	public static void ROTATE_PHY_EX(Transformable obj, Vector3 start, Vector3 target, float time, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ROTATE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f, doingCallback, doneCallback);
	}
	public static void ROTATE_PHY_EX(Transformable obj, Vector3 start, Vector3 target, float time, KeyFrameCallback doneCallback)
	{
		ROTATE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f, null, doneCallback);
	}
	public static void ROTATE_PHY_EX(Transformable obj, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (isEmpty(keyframe) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用void ROTATE_PHY(Transformable obj, Vector3 rotation)");
			return;
		}
		CommandTransformableRotatePhysics cmd = newCmd(out cmd, false, false);
		cmd.mName = keyframe;
		cmd.mOnceLength = onceLength;
		cmd.mStartRotation = start;
		cmd.mTargetRotation = target;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableRotatePhysics ROTATE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 rotation)
	{
		CommandTransformableRotatePhysics cmd = newCmd(out cmd, false, true);
		cmd.mOnceLength = 0.0f;
		cmd.mStartRotation = rotation;
		cmd.mTargetRotation = rotation;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableRotatePhysics ROTATE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float time)
	{
		return ROTATE_PHY_DELAY(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, time, false, 0.0f);
	}
	public static CommandTransformableRotatePhysics ROTATE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength)
	{
		return ROTATE_PHY_DELAY(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f);
	}
	public static CommandTransformableRotatePhysics ROTATE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop)
	{
		return ROTATE_PHY_DELAY(script, obj, delayTime, keyframe, start, target, onceLength, loop, 0.0f);
	}
	public static CommandTransformableRotatePhysics ROTATE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset)
	{
		if (isEmpty(keyframe) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用CommandTransformableRotatePhysics ROTATE_PHY_DELAY(Transformable obj, float delayTime, Vector3 rotation)");
			return null;
		}
		CommandTransformableRotatePhysics cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mOnceLength = onceLength;
		cmd.mStartRotation = start;
		cmd.mTargetRotation = target;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static void ROTATE_SPEED_PHY(Transformable obj)
	{
		ROTATE_SPEED(obj, Vector3.zero, Vector3.zero, Vector3.zero);
	}
	public static void ROTATE_SPEED_PHY(Transformable obj, Vector3 speed)
	{
		ROTATE_SPEED(obj, speed, Vector3.zero, Vector3.zero);
	}
	public static void ROTATE_SPEED_PHY(Transformable obj, Vector3 speed, Vector3 startAngle)
	{
		ROTATE_SPEED(obj, speed, startAngle, Vector3.zero);
	}
	public static void ROTATE_SPEED_PHY(Transformable obj, Vector3 speed, Vector3 startAngle, Vector3 rotateAccelerationValue)
	{
		CommandMovableObjectRotateSpeedPhysics cmd = newCmd(out cmd, false, false);
		cmd.mRotateSpeed = speed;
		cmd.mStartAngle = startAngle;
		cmd.mRotateAcceleration = rotateAccelerationValue;
		pushCommand(cmd, obj);
	}
	public static CommandMovableObjectRotateSpeedPhysics ROTATE_SPEED_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 speed)
	{
		return ROTATE_SPEED_PHY_DELAY(script, obj, delayTime, speed, Vector3.zero, Vector3.zero);
	}
	public static CommandMovableObjectRotateSpeedPhysics ROTATE_SPEED_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 speed, Vector3 startAngle)
	{
		return ROTATE_SPEED_PHY_DELAY(script, obj, delayTime, speed, startAngle, Vector3.zero);
	}
	public static CommandMovableObjectRotateSpeedPhysics ROTATE_SPEED_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 speed, Vector3 startAngle, Vector3 rotateAccelerationValue)
	{
		CommandMovableObjectRotateSpeedPhysics cmd = newCmd(out cmd, false, true);
		cmd.mRotateSpeed = speed;
		cmd.mStartAngle = startAngle;
		cmd.mRotateAcceleration = rotateAccelerationValue;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 以指定角度列表旋转物体
	#region 以指定角度列表旋转物体
	public static void ROTATE_CURVE(Transformable obj)
	{
		pushCommand<CommandTransformableRotateCurve>(obj, false);
	}
	public static void ROTATE_CURVE(Transformable obj, List<Vector3> rotList, float onceLength)
	{
		ROTATE_CURVE_EX(obj, CommonDefine.ZERO_ONE, rotList, onceLength, false, 0.0f, null, null);
	}
	public static void ROTATE_CURVE(Transformable obj, string fileName, List<Vector3> rotList, float onceLength)
	{
		ROTATE_CURVE_EX(obj, fileName, rotList, onceLength, false, 0.0f, null, null);
	}
	public static void ROTATE_CURVE(Transformable obj, string fileName, List<Vector3> rotList, float onceLength, bool loop)
	{
		ROTATE_CURVE_EX(obj, fileName, rotList, onceLength, loop, 0.0f, null, null);
	}
	public static void ROTATE_CURVE(Transformable obj, string fileName, List<Vector3> rotList, float onceLength, bool loop, float offset)
	{
		ROTATE_CURVE_EX(obj, fileName, rotList, onceLength, loop, offset, null, null);
	}
	public static void ROTATE_CURVE_EX(Transformable obj, List<Vector3> rotList, float onceLength, KeyFrameCallback doneCallback)
	{
		ROTATE_CURVE_EX(obj, CommonDefine.ZERO_ONE, rotList, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void ROTATE_CURVE_EX(Transformable obj, List<Vector3> rotList, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ROTATE_CURVE_EX(obj, CommonDefine.ZERO_ONE, rotList, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void ROTATE_CURVE_EX(Transformable obj, List<Vector3> rotList, float onceLength, float offsetTime, KeyFrameCallback doneCallback)
	{
		ROTATE_CURVE_EX(obj, CommonDefine.ZERO_ONE, rotList, onceLength, false, offsetTime, null, doneCallback);
	}
	public static void ROTATE_CURVE_EX(Transformable obj, List<Vector3> rotList, float onceLength, float offsetTime, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ROTATE_CURVE_EX(obj, CommonDefine.ZERO_ONE, rotList, onceLength, false, offsetTime, doingCallback, doneCallback);
	}
	public static void ROTATE_CURVE_EX(Transformable obj, string fileName, List<Vector3> rotList, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ROTATE_CURVE_EX(obj, fileName, rotList, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void ROTATE_CURVE_EX(Transformable obj, string fileName, List<Vector3> rotList, float onceLength, bool loop, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ROTATE_CURVE_EX(obj, fileName, rotList, onceLength, loop, 0.0f, doingCallback, doneCallback);
	}
	public static void ROTATE_CURVE_EX(Transformable obj, string fileName, List<Vector3> rotList, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		CommandTransformableRotateCurve cmd = newCmd(out cmd, false);
		cmd.mName = fileName;
		cmd.mOnceLength = onceLength;
		cmd.mRotList = rotList;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		var cmd = pushDelayCommand<CommandTransformableRotateCurve>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, List<Vector3> rotList, float onceLength)
	{
		return ROTATE_CURVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, rotList, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> rotList, float onceLength)
	{
		return ROTATE_CURVE_DELAY_EX(script, obj, delayTime, keyframe, rotList, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> rotList, float onceLength, bool loop)
	{
		return ROTATE_CURVE_DELAY_EX(script, obj, delayTime, keyframe, rotList, onceLength, loop, 0.0f, null, null);
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> rotList, float onceLength, bool loop, float offset)
	{
		return ROTATE_CURVE_DELAY_EX(script, obj, delayTime, keyframe, rotList, onceLength, loop, offset, null, null);
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, List<Vector3> rotList, float onceLength, KeyFrameCallback doneCallback)
	{
		return ROTATE_CURVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, rotList, onceLength, false, 0.0f, null, doneCallback);
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, List<Vector3> rotList, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return ROTATE_CURVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, rotList, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableRotateCurve ROTATE_CURVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> rotList, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		CommandTransformableRotateCurve cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mRotList = rotList;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 移动
	#region 在普通更新中用关键帧移动物体
	public static void MOVE(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableMove cmd = newCmd(out cmd, false, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartPos = Vector3.zero;
		cmd.mTargetPos = Vector3.zero;
		pushCommand(cmd, obj);
	}
	public static void MOVE(Transformable obj, Vector3 pos)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableMove cmd = newCmd(out cmd, false, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartPos = pos;
		cmd.mTargetPos = pos;
		pushCommand(cmd, obj);
	}
	public static void MOVE(Transformable obj, Vector3 start, Vector3 target, float onceLength)
	{
		MOVE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength)
	{
		MOVE_EX(obj, fileName, startPos, targetPos, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop)
	{
		MOVE_EX(obj, fileName, startPos, targetPos, onceLength, loop, 0.0f, null, null);
	}
	public static void MOVE(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset)
	{
		MOVE_EX(obj, fileName, startPos, targetPos, onceLength, loop, offset, null, null);
	}
	public static void MOVE_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback moveDoneCallback)
	{
		MOVE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, moveDoneCallback);
	}
	public static void MOVE_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback movingCallback, KeyFrameCallback moveDoneCallback)
	{
		MOVE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, movingCallback, moveDoneCallback);
	}
	public static void MOVE_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, float offsetTime, KeyFrameCallback moveDoneCallback)
	{
		MOVE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, offsetTime, null, moveDoneCallback);
	}
	public static void MOVE_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, float offsetTime, KeyFrameCallback movingCallback, KeyFrameCallback moveDoneCallback)
	{
		MOVE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, offsetTime, movingCallback, moveDoneCallback);
	}
	public static void MOVE_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, KeyFrameCallback doneCallback)
	{
		MOVE_EX(obj, fileName, startPos, targetPos, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void MOVE_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_EX(obj, fileName, startPos, targetPos, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, KeyFrameCallback tremblingCallBack, KeyFrameCallback trembleDoneCallBack)
	{
		MOVE_EX(obj, fileName, startPos, targetPos, onceLength, loop, 0.0f, tremblingCallBack, trembleDoneCallBack);
	}
	public static void MOVE_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset, KeyFrameCallback tremblingCallBack, KeyFrameCallback trembleDoneCallBack)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableMove cmd = newCmd(out cmd, false, false);
		cmd.mName = fileName;
		cmd.mOnceLength = onceLength;
		cmd.mStartPos = startPos;
		cmd.mTargetPos = targetPos;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = tremblingCallBack;
		cmd.mTrembleDoneCallBack = trembleDoneCallBack;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableMove MOVE_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 pos)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableMove cmd = newCmd(out cmd, false, true);
		cmd.mStartPos = pos;
		cmd.mTargetPos = pos;
		cmd.mOnceLength = 0.0f;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableMove MOVE_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMove MOVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMove MOVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, loop, 0.0f, null, null);
	}
	public static CommandTransformableMove MOVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, loop, offset, null, null);
	}
	public static CommandTransformableMove MOVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback moveDoneCallback)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, moveDoneCallback);
	}
	public static CommandTransformableMove MOVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback movingCallback, KeyFrameCallback moveDoneCallback)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, movingCallback, moveDoneCallback);
	}
	public static CommandTransformableMove MOVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, KeyFrameCallback moveDoneCallback)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, false, 0.0f, null, moveDoneCallback);
	}
	public static CommandTransformableMove MOVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset, KeyFrameCallback moveDoneCallback)
	{
		return MOVE_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, loop, offset, null, moveDoneCallback);
	}
	public static CommandTransformableMove MOVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset, KeyFrameCallback movingCallback, KeyFrameCallback moveDoneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableMove cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mStartPos = startPos;
		cmd.mTargetPos = targetPos;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = movingCallback;
		cmd.mTrembleDoneCallBack = moveDoneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	#region 在物理更新中用关键帧移动物体
	public static void MOVE_PHY(Transformable obj, Vector3 pos)
	{
		CommandTransformableMovePhysics cmd = newCmd(out cmd, false, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartPos = pos;
		cmd.mTargetPos = pos;
		pushCommand(cmd, obj);
	}
	public static void MOVE_PHY(Transformable obj, Vector3 start, Vector3 target, float onceLength)
	{
		MOVE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE_PHY(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop)
	{
		MOVE_PHY_EX(obj, fileName, startPos, targetPos, onceLength, loop, 0.0f, null, null);
	}
	public static void MOVE_PHY(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset)
	{
		MOVE_PHY_EX(obj, fileName, startPos, targetPos, onceLength, loop, offset, null, null);
	}
	public static void MOV_PHY(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength)
	{
		MOVE_PHY_EX(obj, fileName, startPos, targetPos, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE_PHY_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doneCallback)
	{
		MOVE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void MOVE_PHY_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_PHY_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, float offsetTime, KeyFrameCallback doneCallback)
	{
		MOVE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, offsetTime, null, doneCallback);
	}
	public static void MOVE_PHY_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, float offsetTime, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PHY_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, offsetTime, doingCallback, doneCallback);
	}
	public static void MOVE_PHY_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PHY_EX(obj, fileName, startPos, targetPos, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_PHY_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PHY_EX(obj, fileName, startPos, targetPos, onceLength, loop, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_PHY_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		CommandTransformableMovePhysics cmd = newCmd(out cmd, false, false);
		cmd.mName = fileName;
		cmd.mOnceLength = onceLength;
		cmd.mStartPos = startPos;
		cmd.mTargetPos = targetPos;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 pos)
	{
		CommandTransformableMovePhysics cmd = newCmd(out cmd, false, true);
		cmd.mStartPos = pos;
		cmd.mTargetPos = pos;
		cmd.mOnceLength = 0.0f;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength)
	{
		return MOVE_PHY_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength)
	{
		return MOVE_PHY_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop)
	{
		return MOVE_PHY_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, loop, 0.0f, null, null);
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset)
	{
		return MOVE_PHY_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, onceLength, loop, offset, null, null);
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doneCallback)
	{
		return MOVE_PHY_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return MOVE_PHY_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableMovePhysics MOVE_PHY_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		CommandTransformableMovePhysics cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mStartPos = startPos;
		cmd.mTargetPos = targetPos;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 以抛物线移动物体
	#region 以抛物线移动物体
	public static void MOVE_PARABOLA(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandTransformableMoveParabola>(obj, false);
	}
	public static void MOVE_PARABOLA(Transformable obj, Vector3 start, Vector3 target, float topHeight, float onceLength)
	{
		MOVE_PARABOLA_EX(obj, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE_PARABOLA(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength)
	{
		MOVE_PARABOLA_EX(obj, fileName, startPos, targetPos, topHeight, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE_PARABOLA(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, bool loop)
	{
		MOVE_PARABOLA_EX(obj, fileName, startPos, targetPos, topHeight, onceLength, loop, 0.0f, null, null);
	}
	public static void MOVE_PARABOLA(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, bool loop, float offset)
	{
		MOVE_PARABOLA_EX(obj, fileName, startPos, targetPos, topHeight, onceLength, loop, offset, null, null);
	}
	public static void MOVE_PARABOLA_EX(Transformable obj, Vector3 start, Vector3 target, float topHeight, float onceLength, KeyFrameCallback doneCallback)
	{
		MOVE_PARABOLA_EX(obj, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void MOVE_PARABOLA_EX(Transformable obj, Vector3 start, Vector3 target, float topHeight, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PARABOLA_EX(obj, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_PARABOLA_EX(Transformable obj, Vector3 start, Vector3 target, float topHeight, float onceLength, float offsetTime, KeyFrameCallback doneCallback)
	{
		MOVE_PARABOLA_EX(obj, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, offsetTime, null, doneCallback);
	}
	public static void MOVE_PARABOLA_EX(Transformable obj, Vector3 start, Vector3 target, float topHeight, float onceLength, float offsetTime, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PARABOLA_EX(obj, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, offsetTime, doingCallback, doneCallback);
	}
	public static void MOVE_PARABOLA_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PARABOLA_EX(obj, fileName, startPos, targetPos, topHeight, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_PARABOLA_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, bool loop, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_PARABOLA_EX(obj, fileName, startPos, targetPos, topHeight, onceLength, loop, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_PARABOLA_EX(Transformable obj, string fileName, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableMoveParabola cmd = newCmd(out cmd, false, false);
		cmd.mName = fileName;
		cmd.mOnceLength = onceLength;
		cmd.mStartPos = startPos;
		cmd.mTargetPos = targetPos;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTopHeight = topHeight;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandTransformableMoveParabola>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float topHeight, float onceLength)
	{
		return MOVE_PARABOLA_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength)
	{
		return MOVE_PARABOLA_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, topHeight, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, bool loop)
	{
		return MOVE_PARABOLA_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, topHeight, onceLength, loop, 0.0f, null, null);
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, bool loop, float offset)
	{
		return MOVE_PARABOLA_DELAY_EX(script, obj, delayTime, keyframe, startPos, targetPos, topHeight, onceLength, loop, offset, null, null);
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float topHeight, float onceLength, KeyFrameCallback doneCallback)
	{
		return MOVE_PARABOLA_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, 0.0f, null, doneCallback);
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float topHeight, float onceLength, KeyFrameCallback movingCallback, KeyFrameCallback doneCallback)
	{
		return MOVE_PARABOLA_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, topHeight, onceLength, false, 0.0f, movingCallback, doneCallback);
	}
	public static CommandTransformableMoveParabola MOVE_PARABOLA_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 startPos, Vector3 targetPos, float topHeight, float onceLength, bool loop, float offset, KeyFrameCallback movingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableMoveParabola cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mStartPos = startPos;
		cmd.mTargetPos = targetPos;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTopHeight = topHeight;
		cmd.mTremblingCallBack = movingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 以指定点列表的路线移动物体
	#region 以指定点列表的路线移动物体
	public static void MOVE_CURVE(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandTransformableMoveCurve>(obj, false);
	}
	public static void MOVE_CURVE(Transformable obj, List<Vector3> posList, float onceLength)
	{
		MOVE_CURVE_EX(obj, CommonDefine.ZERO_ONE, posList, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE_CURVE(Transformable obj, string fileName, List<Vector3> posList, float onceLength)
	{
		MOVE_CURVE_EX(obj, fileName, posList, onceLength, false, 0.0f, null, null);
	}
	public static void MOVE_CURVE(Transformable obj, string fileName, List<Vector3> posList, float onceLength, bool loop)
	{
		MOVE_CURVE_EX(obj, fileName, posList, onceLength, loop, 0.0f, null, null);
	}
	public static void MOVE_CURVE(Transformable obj, string fileName, List<Vector3> posList, float onceLength, bool loop, float offset)
	{
		MOVE_CURVE_EX(obj, fileName, posList, onceLength, loop, offset, null, null);
	}
	public static void MOVE_CURVE_EX(Transformable obj, List<Vector3> posList, float onceLength, KeyFrameCallback doneCallback)
	{
		MOVE_CURVE_EX(obj, CommonDefine.ZERO_ONE, posList, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void MOVE_CURVE_EX(Transformable obj, List<Vector3> posList, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_CURVE_EX(obj, CommonDefine.ZERO_ONE, posList, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_CURVE_EX(Transformable obj, List<Vector3> posList, float onceLength, float offsetTime, KeyFrameCallback doneCallback)
	{
		MOVE_CURVE_EX(obj, CommonDefine.ZERO_ONE, posList, onceLength, false, offsetTime, null, doneCallback);
	}
	public static void MOVE_CURVE_EX(Transformable obj, List<Vector3> posList, float onceLength, float offsetTime, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_CURVE_EX(obj, CommonDefine.ZERO_ONE, posList, onceLength, false, offsetTime, doingCallback, doneCallback);
	}
	public static void MOVE_CURVE_EX(Transformable obj, string fileName, List<Vector3> posList, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_CURVE_EX(obj, fileName, posList, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_CURVE_EX(Transformable obj, string fileName, List<Vector3> posList, float onceLength, bool loop, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		MOVE_CURVE_EX(obj, fileName, posList, onceLength, loop, 0.0f, doingCallback, doneCallback);
	}
	public static void MOVE_CURVE_EX(Transformable obj, string fileName, List<Vector3> posList, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableMoveCurve cmd = newCmd(out cmd, false);
		cmd.mName = fileName;
		cmd.mOnceLength = onceLength;
		cmd.mPosList = posList;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandTransformableMoveCurve>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, List<Vector3> posList, float onceLength)
	{
		return MOVE_CURVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, posList, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> posList, float onceLength)
	{
		return MOVE_CURVE_DELAY_EX(script, obj, delayTime, keyframe, posList, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> posList, float onceLength, bool loop)
	{
		return MOVE_CURVE_DELAY_EX(script, obj, delayTime, keyframe, posList, onceLength, loop, 0.0f, null, null);
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> posList, float onceLength, bool loop, float offset)
	{
		return MOVE_CURVE_DELAY_EX(script, obj, delayTime, keyframe, posList, onceLength, loop, offset, null, null);
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, List<Vector3> posList, float onceLength, KeyFrameCallback doneCallback)
	{
		return MOVE_CURVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, posList, onceLength, false, 0.0f, null, doneCallback);
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, List<Vector3> posList, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return MOVE_CURVE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, posList, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableMoveCurve MOVE_CURVE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, List<Vector3> posList, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableMoveCurve cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mPosList = posList;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//-----------------------------------------------------------------------------------------------------------------------------------
	// 以指定点列表以及时间点的路线移动物体
	#region 以指定点列表以及时间点的路线移动物体
	public static void MOVE_PATH(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandTransformableMovePath>(obj, false);
	}
	public static void MOVE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame)
	{
		MOVE_PATH_EX(obj, valueKeyFrame, Vector3.zero, 1.0f, false, 0.0f, null, null);
	}
	public static void MOVE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset)
	{
		MOVE_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static void MOVE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed)
	{
		MOVE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static void MOVE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop)
	{
		MOVE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static void MOVE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, KeyFrameCallback doneCallback)
	{
		MOVE_PATH_EX(obj, valueKeyFrame, Vector3.zero, 1.0f, false, 0.0f, null, doneCallback);
	}
	public static void MOVE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, KeyFrameCallback doneCallback)
	{
		MOVE_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, doneCallback);
	}
	public static void MOVE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		MOVE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static void MOVE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableMovePath cmd = newCmd(out cmd, false);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandTransformableMovePath>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame)
	{
		return MOVE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, Vector3.zero, 1.0f, false, 0.0f, null, null);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset)
	{
		return MOVE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed)
	{
		return MOVE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop)
	{
		return MOVE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset)
	{
		return MOVE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, offset, null, null);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		return MOVE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return MOVE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableMovePath MOVE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableMovePath cmd = newCmd(out cmd, false, true);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//------------------------------------------------------------------------------------------------------------------
	// 插值位置
	#region 插值位置
	public static void LERP_POSITION(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandTransformableLerpPosition>(obj, false);
	}
	public static void LERP_POSITION(Transformable obj, Vector3 targetPosition, float lerpSpeed)
	{
		LERP_POSITION_EX(obj, targetPosition, lerpSpeed, null, null);
	}
	public static void LERP_POSITION_EX(Transformable obj, Vector3 targetPosition, float lerpSpeed, LerpCallback doneCallback)
	{
		LERP_POSITION_EX(obj, targetPosition, lerpSpeed, null, doneCallback);
	}
	public static void LERP_POSITION_EX(Transformable obj, Vector3 targetPosition, float lerpSpeed, LerpCallback doingCallback, LerpCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		if (isFloatZero(lerpSpeed))
		{
			logError("速度不能为0,如果要停止组件,请使用void LERP_POSITION(Transformable obj)");
			return;
		}
		CommandTransformableLerpPosition cmd = newCmd(out cmd, false);
		cmd.mTargetPosition = targetPosition;
		cmd.mLerpSpeed = lerpSpeed;
		cmd.mLerpingCallBack = doingCallback;
		cmd.mLerpDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableLerpPosition LERP_POSITION_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandTransformableLerpPosition>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableLerpPosition LERP_POSITION_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 targetPosition, float lerpSpeed)
	{
		return LERP_POSITION_DELAY_EX(script, obj, delayTime, targetPosition, lerpSpeed, null, null);
	}
	public static CommandTransformableLerpPosition LERP_POSITION_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 targetPosition, float lerpSpeed, LerpCallback doneCallback)
	{
		return LERP_POSITION_DELAY_EX(script, obj, delayTime, targetPosition, lerpSpeed, null, doneCallback);
	}
	public static CommandTransformableLerpPosition LERP_POSITION_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 targetPosition, float lerpSpeed, LerpCallback doingCallback, LerpCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		if (isFloatZero(lerpSpeed))
		{
			logError("速度不能为0,如果要停止组件,请使用void LERP_POSITION_DELAY(LayoutScript script, Transformable obj, float delayTime)");
			return null;
		}
		CommandTransformableLerpPosition cmd = newCmd(out cmd, false, true);
		cmd.mTargetPosition = targetPosition;
		cmd.mLerpSpeed = lerpSpeed;
		cmd.mLerpingCallBack = doingCallback;
		cmd.mLerpDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//------------------------------------------------------------------------------------------------------------------
	// 插值旋转
	#region 插值旋转
	public static void LERP_ROTATION(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandTransformableLerpRotation>(obj, false);
	}
	public static void LERP_ROTATION(Transformable obj, Vector3 targetRotation, float lerpSpeed)
	{
		LERP_ROTATION_EX(obj, targetRotation, lerpSpeed, null, null);
	}
	public static void LERP_ROTATION_EX(Transformable obj, Vector3 targetRotation, float lerpSpeed, LerpCallback doneCallback)
	{
		LERP_ROTATION_EX(obj, targetRotation, lerpSpeed, null, doneCallback);
	}
	public static void LERP_ROTATION_EX(Transformable obj, Vector3 targetRotation, float lerpSpeed, LerpCallback doingCallback, LerpCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		if (isFloatZero(lerpSpeed))
		{
			logError("速度不能为0,如果要停止组件,请使用void LERP_ROTATION(Transformable obj)");
			return;
		}
		CommandTransformableLerpRotation cmd = newCmd(out cmd, false);
		cmd.mTargetRotation = targetRotation;
		cmd.mLerpSpeed = lerpSpeed;
		cmd.mLerpingCallBack = doingCallback;
		cmd.mLerpDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableLerpRotation LERP_ROTATION_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandTransformableLerpRotation>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableLerpRotation LERP_ROTATION_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 targetRotation, float lerpSpeed)
	{
		return LERP_ROTATION_DELAY_EX(script, obj, delayTime, targetRotation, lerpSpeed, null, null);
	}
	public static CommandTransformableLerpRotation LERP_ROTATION_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 targetRotation, float lerpSpeed, LerpCallback doneCallback)
	{
		return LERP_ROTATION_DELAY_EX(script, obj, delayTime, targetRotation, lerpSpeed, null, doneCallback);
	}
	public static CommandTransformableLerpRotation LERP_ROTATION_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 targetRotation, float lerpSpeed, LerpCallback doingCallback, LerpCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		if (isFloatZero(lerpSpeed))
		{
			logError("速度不能为0,如果要停止组件,请使用void LERP_ROTATION_DELAY(LayoutScript script, Transformable obj, float delayTime)");
			return null;
		}
		CommandTransformableLerpRotation cmd = newCmd(out cmd, false, true);
		cmd.mTargetRotation = targetRotation;
		cmd.mLerpSpeed = lerpSpeed;
		cmd.mLerpingCallBack = doingCallback;
		cmd.mLerpDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//-----------------------------------------------------------------------------------------------------------------------------------
	// 以指定点列表以及时间点的路线旋转物体
	#region 以指定点列表以及时间点的路线旋转物体
	public static void ROTATE_PATH(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandTransformableRotatePath>(obj, false);
	}
	public static void ROTATE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame)
	{
		ROTATE_PATH_EX(obj, valueKeyFrame, Vector3.zero, 1.0f, false, 0.0f, null, null);
	}
	public static void ROTATE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset)
	{
		ROTATE_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static void ROTATE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed)
	{
		ROTATE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static void ROTATE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop)
	{
		ROTATE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static void ROTATE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, KeyFrameCallback doneCallback)
	{
		ROTATE_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, doneCallback);
	}
	public static void ROTATE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		ROTATE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static void ROTATE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableRotatePath cmd = newCmd(out cmd, false);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandTransformableRotatePath>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame)
	{
		return ROTATE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, Vector3.zero, 1.0f, false, 0.0f, null, null);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset)
	{
		return ROTATE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed)
	{
		return ROTATE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop)
	{
		return ROTATE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset)
	{
		return ROTATE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, offset, null, null);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		return ROTATE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return ROTATE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableRotatePath ROTATE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableRotatePath cmd = newCmd(out cmd, false, true);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 追踪物体
	#region 追踪物体
	public static void TRACK_TARGET(Transformable obj)
	{
		TRACK_TARGET(obj, null, 0.0f, Vector3.zero, null, null);
	}
	public static void TRACK_TARGET(Transformable obj, Transformable target, float speed)
	{
		TRACK_TARGET(obj, target, speed, Vector3.zero, null, null);
	}
	public static void TRACK_TARGET(Transformable obj, Transformable target, float speed, TrackCallback doneCallback)
	{
		TRACK_TARGET(obj, target, speed, Vector3.zero, null, doneCallback);
	}
	public static void TRACK_TARGET(Transformable obj, Transformable target, float speed, Vector3 offset)
	{
		TRACK_TARGET(obj, target, speed, offset, null, null);
	}
	public static void TRACK_TARGET(Transformable obj, Transformable target, float speed, TrackCallback doingCallback, TrackCallback doneCallback)
	{
		TRACK_TARGET(obj, target, speed, Vector3.zero, doingCallback, doneCallback);
	}
	public static void TRACK_TARGET(Transformable obj, Transformable target, float speed, Vector3 offset, TrackCallback trackingCallback, TrackCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableTrackTarget cmd = newCmd(out cmd, false);
		cmd.mTarget = target;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mDoingCallback = trackingCallback;
		cmd.mDoneCallback = doneCallback;
		pushCommand(cmd, obj);
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 始终朝向物体
	#region 始终朝向物体
	public static void ROTATE_FOCUS(Transformable obj)
	{
		ROTATE_FOCUS(obj, null, Vector3.zero);
	}
	public static void ROTATE_FOCUS(Transformable obj, Transformable target)
	{
		ROTATE_FOCUS(obj, target, Vector3.zero);
	}
	public static void ROTATE_FOCUS(Transformable obj, Transformable target, Vector3 offset)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableRotateFocus cmd = newCmd(out cmd, false);
		cmd.mTarget = target;
		cmd.mOffset = offset;
		pushCommand(cmd, obj);
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 锁定世界坐标分量
	#region 锁定世界坐标的指定分量
	public static void LOCK_POSITION_X(Transformable obj, float x)
	{
		LOCK_POSITION(obj, new Vector3(x, 0.0f, 0.0f), true, false, false);
	}
	public static void LOCK_POSITION_Y(Transformable obj, float y)
	{
		LOCK_POSITION(obj, new Vector3(0.0f, y, 0.0f), false, true, false);
	}
	public static void LOCK_POSITION_Z(Transformable obj, float z)
	{
		LOCK_POSITION(obj, new Vector3(0.0f, 0.0f, z), false, false, true);
	}
	public static void LOCK_POSITION(Transformable obj)
	{
		LOCK_POSITION(obj, Vector3.zero, false, false, false);
	}
	public static void LOCK_POSITION(Transformable obj, Vector3 pos, bool lockX, bool lockY, bool lockZ)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableLockPosition cmd = newCmd(out cmd, false);
		cmd.mLockPosition = pos;
		cmd.mLockX = lockX;
		cmd.mLockY = lockY;
		cmd.mLockZ = lockZ;
		pushCommand(cmd, obj);
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 缩放
	#region 用关键帧缩放物体
	public static void SCALE(Transformable obj)
	{
		SCALE(obj, Vector3.one);
	}
	public static void SCALE(Transformable obj, Vector3 scale)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableScale cmd = newCmd(out cmd, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartScale = scale;
		cmd.mTargetScale = scale;
		pushCommand(cmd, obj);
	}
	public static void SCALE(Transformable obj, Vector3 start, Vector3 target, float onceLength)
	{
		SCALE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void SCALE(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void SCALE(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, bool loop)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, loop, 0.0f, null, null);
	}
	public static void SCALE(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, bool loop, float offset)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, loop, offset, null, null);
	}
	public static void SCALE_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doneCallback)
	{
		SCALE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void SCALE_EX(Transformable obj, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		SCALE_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void SCALE_EX(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doneCallback)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void SCALE_EX(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, bool loop, KeyFrameCallback doneCallback)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, loop, 0.0f, null, doneCallback);
	}
	public static void SCALE_EX(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, bool loop, float offset, KeyFrameCallback doneCallback)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, loop, offset, null, doneCallback);
	}
	public static void SCALE_EX(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void SCALE_EX(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, bool loop, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		SCALE_EX(obj, fileName, start, target, onceLength, loop, 0.0f, doingCallback, doneCallback);
	}
	public static void SCALE_EX(Transformable obj, string fileName, Vector3 start, Vector3 target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableScale cmd = newCmd(out cmd, false);
		cmd.mName = fileName;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mStartScale = start;
		cmd.mTargetScale = target;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableScale SCALE_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 scale)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableScale cmd = newCmd(out cmd, false, true);
		cmd.mOnceLength = 0.0f;
		cmd.mStartScale = scale;
		cmd.mTargetScale = scale;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableScale SCALE_DELAY(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength)
	{
		return SCALE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableScale SCALE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength)
	{
		return SCALE_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandTransformableScale SCALE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop)
	{
		return SCALE_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, loop, 0.0f, null, null);
	}
	public static CommandTransformableScale SCALE_DELAY(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset)
	{
		return SCALE_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, loop, offset, null, null);
	}
	public static CommandTransformableScale SCALE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return SCALE_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableScale SCALE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return SCALE_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableScale SCALE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return SCALE_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, loop, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableScale SCALE_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableScale cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mStartScale = start;
		cmd.mTargetScale = target;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//-----------------------------------------------------------------------------------------------------------------------------------
	// 以指定点列表以及时间点的路线缩放物体
	#region 以指定点列表以及时间点的路线缩放物体
	public static void SCALE_PATH(Transformable obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandTransformableScalePath>(obj, false);
	}
	public static void SCALE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame)
	{
		SCALE_PATH_EX(obj, valueKeyFrame, Vector3.one, 1.0f, false, 0.0f, null, null);
	}
	public static void SCALE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset)
	{
		SCALE_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static void SCALE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed)
	{
		SCALE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static void SCALE_PATH(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop)
	{
		SCALE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static void SCALE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, KeyFrameCallback doneCallback)
	{
		SCALE_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, doneCallback);
	}
	public static void SCALE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		SCALE_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static void SCALE_PATH_EX(Transformable obj, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandTransformableScalePath cmd = newCmd(out cmd, false);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandTransformableScalePath>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame)
	{
		return SCALE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, Vector3.one, 1.0f, false, 0.0f, null, null);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset)
	{
		return SCALE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed)
	{
		return SCALE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop)
	{
		return SCALE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset)
	{
		return SCALE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, offset, null, null);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		return SCALE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return SCALE_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandTransformableScalePath SCALE_PATH_DELAY_EX(LayoutScript script, Transformable obj, float delayTime, Dictionary<float, Vector3> valueKeyFrame, Vector3 valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandTransformableScalePath cmd = newCmd(out cmd, false, true);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//-----------------------------------------------------------------------------------------------------------------------------------------------------------
	// 进度条
	#region 进度条
	public static void SLIDER(ComponentOwner slider, float value)
	{
		CommandWindowSlider cmd = newCmd(out cmd, false);
		cmd.mStartValue = value;
		cmd.mTargetValue = value;
		cmd.mOnceLength = 0.0f;
		pushCommand(cmd, slider);
	}
	public static void SLIDER(ComponentOwner slider, float start, float target, float time)
	{
		CommandWindowSlider cmd = newCmd(out cmd, false);
		cmd.mStartValue = start;
		cmd.mTargetValue = target;
		cmd.mOnceLength = time;
		cmd.mTremblingName = CommonDefine.ZERO_ONE;
		pushCommand(cmd, slider);
	}
	#endregion
	// 窗口填充
	#region 窗口填充
	public static void FILL(txUIObject obj, float value)
	{
		CommandWindowFill cmd = newCmd(out cmd, false);
		cmd.mStartValue = value;
		cmd.mTargetValue = value;
		cmd.mOnceLength = 0.0f;
		pushCommand(cmd, obj);
	}
	public static void FILL(txUIObject obj, float start, float target, float time)
	{
		CommandWindowFill cmd = newCmd(out cmd, false);
		cmd.mStartValue = start;
		cmd.mTargetValue = target;
		cmd.mOnceLength = time;
		cmd.mTremblingName = CommonDefine.ZERO_ONE;
		pushCommand(cmd, obj);
	}
	public static CommandWindowFill FILL_DELAY(LayoutScript script, txUIObject obj, float delayTime, float start, float target, float time)
	{
		CommandWindowFill cmd = newCmd(out cmd, false, true);
		cmd.mStartValue = start;
		cmd.mTargetValue = target;
		cmd.mOnceLength = time;
		cmd.mTremblingName = CommonDefine.ZERO_ONE;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandWindowFill FILL_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, float start, float target, float time, KeyFrameCallback doneCallback)
	{
		CommandWindowFill cmd = newCmd(out cmd, false, true);
		cmd.mStartValue = start;
		cmd.mTargetValue = target;
		cmd.mOnceLength = time;
		cmd.mTremblingName = CommonDefine.ZERO_ONE;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static void FILL_EX(txUIObject obj, float start, float target, float time, KeyFrameCallback fillingCallback, KeyFrameCallback doneCallback)
	{
		CommandWindowFill cmd = newCmd(out cmd, false);
		cmd.mStartValue = start;
		cmd.mTargetValue = target;
		cmd.mOnceLength = time;
		cmd.mTremblingName = CommonDefine.ZERO_ONE;
		cmd.mTremblingCallBack = fillingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	#endregion
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// 透明度
	#region 透明度
	public static void ALPHA(txUIObject obj, float alpha = 1.0f)
	{
		CommandWindowAlpha cmd = newCmd(out cmd, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartAlpha = alpha;
		cmd.mTargetAlpha = alpha;
		pushCommand(cmd, obj);
	}
	public static void ALPHA(txUIObject obj, float start, float target, float onceLength)
	{
		ALPHA_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void ALPHA(txUIObject obj, string name, float start, float target, float onceLength)
	{
		ALPHA_EX(obj, name, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void ALPHA(txUIObject obj, string name, float start, float target, float onceLength, bool loop)
	{
		ALPHA_EX(obj, name, start, target, onceLength, loop, 0.0f, null, null);
	}
	public static void ALPHA(txUIObject obj, string name, float start, float target, float onceLength, bool loop, float offset)
	{
		ALPHA_EX(obj, name, start, target, onceLength, loop, offset, null, null);
	}
	public static void ALPHA_EX(txUIObject obj, float start, float target, float onceLength, KeyFrameCallback doneCallback)
	{
		ALPHA_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void ALPHA_EX(txUIObject obj, float start, float target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ALPHA_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void ALPHA_EX(txUIObject obj, string name, float start, float target, float onceLength, KeyFrameCallback doneCallback)
	{
		ALPHA_EX(obj, name, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void ALPHA_EX(txUIObject obj, string name, float start, float target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		ALPHA_EX(obj, name, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void ALPHA_EX(txUIObject obj, string name, float start, float target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (isEmpty(name) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用void ALPHA(txUIObject obj, float alpha)");
			return;
		}
		CommandWindowAlpha cmd = newCmd(out cmd, false);
		cmd.mName = name;
		cmd.mLoop = loop;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mStartAlpha = start;
		cmd.mTargetAlpha = target;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandWindowAlpha ALPHA_DELAY(LayoutScript script, txUIObject obj, float delayTime, float alpha)
	{
		CommandWindowAlpha cmd = newCmd(out cmd, false, true);
		cmd.mOnceLength = 0.0f;
		cmd.mStartAlpha = alpha;
		cmd.mTargetAlpha = alpha;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandWindowAlpha ALPHA_DELAY(LayoutScript script, txUIObject obj, float delayTime, float start, float target, float onceLength)
	{
		return ALPHA_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandWindowAlpha ALPHA_DELAY(LayoutScript script, txUIObject obj, float delayTime, string keyframe, float start, float target, float onceLength)
	{
		return ALPHA_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandWindowAlpha ALPHA_DELAY(LayoutScript script, txUIObject obj, float delayTime, string keyframe, float start, float target, float onceLength, bool loop)
	{
		return ALPHA_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, loop, 0.0f, null, null);
	}
	public static CommandWindowAlpha ALPHA_DELAY(LayoutScript script, txUIObject obj, float delayTime, string keyframe, float start, float target, float onceLength, bool loop, float offset)
	{
		return ALPHA_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, loop, offset, null, null);
	}
	public static CommandWindowAlpha ALPHA_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, float start, float target, float onceLength, KeyFrameCallback doneCallback)
	{
		return ALPHA_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static CommandWindowAlpha ALPHA_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, float start, float target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return ALPHA_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandWindowAlpha ALPHA_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, string keyframe, float start, float target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return ALPHA_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandWindowAlpha ALPHA_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, string keyframe, float start, float target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (isEmpty(keyframe) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用CommandWindowAlpha ALPHA_DELAY(LayoutScript script, txUIObject obj, float delayTime, float alpha)");
			return null;
		}
		CommandWindowAlpha cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mLoop = loop;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mStartAlpha = start;
		cmd.mTargetAlpha = target;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// 颜色,也包含透明度
	#region 颜色
	public static void COLOR(txUIObject obj, Color color)
	{
		CommandWindowColor cmd = newCmd(out cmd, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartColor = color;
		cmd.mTargetColor = color;
		pushCommand(cmd, obj);
	}
	public static void COLOR(txUIObject obj, Color start, Color target, float onceLength)
	{
		COLOR_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void COLOR(txUIObject obj, string name, Color start, Color target, float onceLength)
	{
		COLOR_EX(obj, name, start, target, onceLength, false, 0.0f, null, null);
	}
	public static void COLOR(txUIObject obj, string name, Color start, Color target, float onceLength, bool loop)
	{
		COLOR_EX(obj, name, start, target, onceLength, loop, 0.0f, null, null);
	}
	public static void COLOR(txUIObject obj, string name, Color start, Color target, float onceLength, bool loop, float offset)
	{
		COLOR_EX(obj, name, start, target, onceLength, loop, offset, null, null);
	}
	public static void COLOR_EX(txUIObject obj, Color start, Color target, float onceLength, KeyFrameCallback doneCallback)
	{
		COLOR_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void COLOR_EX(txUIObject obj, Color start, Color target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		COLOR_EX(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void COLOR_EX(txUIObject obj, string name, Color start, Color target, float onceLength, KeyFrameCallback doneCallback)
	{
		COLOR_EX(obj, name, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static void COLOR_EX(txUIObject obj, string name, Color start, Color target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		COLOR_EX(obj, name, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static void COLOR_EX(txUIObject obj, string name, Color start, Color target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (isEmpty(name) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用void ALPHA(txUIObject obj, float alpha)");
			return;
		}
		CommandWindowColor cmd = newCmd(out cmd, false);
		cmd.mName = name;
		cmd.mLoop = loop;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mStartColor = start;
		cmd.mTargetColor = target;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandWindowColor COLOR_DELAY(LayoutScript script, txUIObject obj, float delayTime, Color color)
	{
		CommandWindowColor cmd = newCmd(out cmd, false, true);
		cmd.mOnceLength = 0.0f;
		cmd.mStartColor = color;
		cmd.mTargetColor = color;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandWindowColor COLOR_DELAY(LayoutScript script, txUIObject obj, float delayTime, Color start, Color target, float onceLength)
	{
		return COLOR_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandWindowColor COLOR_DELAY(LayoutScript script, txUIObject obj, float delayTime, string keyframe, Color start, Color target, float onceLength)
	{
		return COLOR_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f, null, null);
	}
	public static CommandWindowColor COLOR_DELAY(LayoutScript script, txUIObject obj, float delayTime, string keyframe, Color start, Color target, float onceLength, bool loop)
	{
		return COLOR_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, loop, 0.0f, null, null);
	}
	public static CommandWindowColor COLOR_DELAY(LayoutScript script, txUIObject obj, float delayTime, string keyframe, Color start, Color target, float onceLength, bool loop, float offset)
	{
		return COLOR_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, loop, offset, null, null);
	}
	public static CommandWindowColor COLOR_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, Color start, Color target, float onceLength, KeyFrameCallback doneCallback)
	{
		return COLOR_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, null, doneCallback);
	}
	public static CommandWindowColor COLOR_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, Color start, Color target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return COLOR_DELAY_EX(script, obj, delayTime, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandWindowColor COLOR_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, string keyframe, Color start, Color target, float onceLength, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return COLOR_DELAY_EX(script, obj, delayTime, keyframe, start, target, onceLength, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandWindowColor COLOR_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, string keyframe, Color start, Color target, float onceLength, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (isEmpty(keyframe) || isFloatZero(onceLength))
		{
			logError("时间或关键帧不能为空,如果要停止组件,请使用CommandWindowAlpha ALPHA_DELAY(LayoutScript script, txUIObject obj, float delayTime, float alpha)");
			return null;
		}
		CommandWindowColor cmd = newCmd(out cmd, false, true);
		cmd.mName = keyframe;
		cmd.mLoop = loop;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mStartColor = start;
		cmd.mTargetColor = target;
		cmd.mTremblingCallBack = doingCallback;
		cmd.mTrembleDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//-----------------------------------------------------------------------------------------------------------------------------------
	// 以指定点列表以及时间点的路线设置物体透明度
	#region 以指定点列表以及时间点的路线设置物体透明度
	public static void ALPHA_PATH(txUIObject obj)
	{
		if (obj == null)
		{
			return;
		}
		pushCommand<CommandWindowAlphaPath>(obj, false);
	}
	public static void ALPHA_PATH(txUIObject obj, Dictionary<float, float> valueKeyFrame)
	{
		ALPHA_PATH_EX(obj, valueKeyFrame, 1.0f, 1.0f, false, 0.0f, null, null);
	}
	public static void ALPHA_PATH(txUIObject obj, Dictionary<float, float> valueKeyFrame, float valueOffset)
	{
		ALPHA_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static void ALPHA_PATH(txUIObject obj, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed)
	{
		ALPHA_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static void ALPHA_PATH(txUIObject obj, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, bool loop)
	{
		ALPHA_PATH_EX(obj, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static void ALPHA_PATH_EX(txUIObject obj, Dictionary<float, float> valueKeyFrame, float valueOffset, KeyFrameCallback doneCallback)
	{
		ALPHA_PATH_EX(obj, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, doneCallback);
	}
	public static void ALPHA_PATH_EX(txUIObject obj, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		ALPHA_PATH_EX(obj, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static void ALPHA_PATH_EX(txUIObject obj, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return;
		}
		CommandWindowAlphaPath cmd = newCmd(out cmd, false);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushCommand(cmd, obj);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY(LayoutScript script, txUIObject obj, float delayTime)
	{
		if (obj == null)
		{
			return null;
		}
		var cmd = pushDelayCommand<CommandWindowAlphaPath>(obj, delayTime, false);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame)
	{
		return ALPH_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, 1.0f, 1.0f, false, 0.0f, null, null);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame, float valueOffset)
	{
		return ALPH_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, 1.0f, false, 0.0f, null, null);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed)
	{
		return ALPH_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, null);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, bool loop)
	{
		return ALPH_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, 0.0f, null, null);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, bool loop, float offset)
	{
		return ALPH_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, loop, offset, null, null);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, KeyFrameCallback doneCallback)
	{
		return ALPH_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, null, doneCallback);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		return ALPH_PATH_DELAY_EX(script, obj, delayTime, valueKeyFrame, valueOffset, speed, false, 0.0f, doingCallback, doneCallback);
	}
	public static CommandWindowAlphaPath ALPH_PATH_DELAY_EX(LayoutScript script, txUIObject obj, float delayTime, Dictionary<float, float> valueKeyFrame, float valueOffset, float speed, bool loop, float offset, KeyFrameCallback doingCallback, KeyFrameCallback doneCallback)
	{
		if (obj == null)
		{
			return null;
		}
		CommandWindowAlphaPath cmd = newCmd(out cmd, false, true);
		cmd.mValueKeyFrame = valueKeyFrame;
		cmd.mValueOffset = valueOffset;
		cmd.mSpeed = speed;
		cmd.mOffset = offset;
		cmd.mLoop = loop;
		cmd.mDoingCallBack = doingCallback;
		cmd.mDoneCallBack = doneCallback;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// HSL
	#region HSL
	public static void HSL(txUIObject obj, Vector3 hsl)
	{
		CommandWindowHSL cmd = newCmd(out cmd, false, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartHSL = hsl;
		cmd.mTargetHSL = hsl;
		pushCommand(cmd, obj);
	}
	public static void HSL(txUIObject obj, Vector3 start, Vector3 target, float onceLength)
	{
		HSL(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f);
	}
	public static void HSL(txUIObject obj, string keyframe, Vector3 start, Vector3 target, float onceLength)
	{
		HSL(obj, keyframe, start, target, onceLength, false, 0.0f);
	}
	public static void HSL(txUIObject obj, string keyframe, Vector3 start, Vector3 target, float onceLength, bool loop, float offset)
	{
		CommandWindowHSL cmd = newCmd(out cmd, false, false);
		cmd.mName = keyframe;
		cmd.mLoop = loop;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mStartHSL = start;
		cmd.mTargetHSL = target;
		pushCommand(cmd, obj);
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------------------
	// 亮度
	#region 亮度
	public static void LUM(txUIObject obj, float lum)
	{
		CommandWindowLum cmd = newCmd(out cmd, false, false);
		cmd.mOnceLength = 0.0f;
		cmd.mStartLum = lum;
		cmd.mTargetLum = lum;
		pushCommand(cmd, obj);
	}
	public static void LUM(txUIObject obj, float start, float target, float onceLength)
	{
		LUM(obj, CommonDefine.ZERO_ONE, start, target, onceLength, false, 0.0f);
	}
	public static void LUM(txUIObject obj, string keyframe, float start, float target, float onceLength)
	{
		LUM(obj, keyframe, start, target, onceLength, false, 0.0f);
	}
	public static void LUM(txUIObject obj, string keyframe, float start, float target, float onceLength, bool loop, float offset)
	{
		CommandWindowLum cmd = newCmd(out cmd, false, false);
		cmd.mName = keyframe;
		cmd.mLoop = loop;
		cmd.mOnceLength = onceLength;
		cmd.mOffset = offset;
		cmd.mStartLum = start;
		cmd.mTargetLum = target;
		pushCommand(cmd, obj);
	}
	#endregion
	//--------------------------------------------------------------------------------------------------------------------------------------------
	// 音效
	#region 播放界面音效
	public static void AUDIO(txUIObject obj)
	{
		pushCommand<CommandWindowPlayAudio>(obj, false);
	}
	public static void AUDIO(txUIObject obj, SOUND_DEFINE sound)
	{
		AUDIO(obj, sound, false, 1.0f);
	}
	public static void AUDIO(txUIObject obj, SOUND_DEFINE sound, bool loop)
	{
		AUDIO(obj, sound, loop, 1.0f);
	}
	public static void AUDIO(txUIObject obj, SOUND_DEFINE sound, bool loop, float volume)
	{
		CommandWindowPlayAudio cmd = newCmd(out cmd, false);
		cmd.mSound = sound;
		cmd.mLoop = loop;
		cmd.mVolume = volume;
		pushCommand(cmd, obj);
	}
	// fileName为sound文件夹的相对路径,
	public static void AUDIO(txUIObject obj, string fileName, bool loop, float volume)
	{
		CommandWindowPlayAudio cmd = newCmd(out cmd, false);
		cmd.mSoundFileName = fileName;
		cmd.mLoop = loop;
		cmd.mVolume = volume;
		pushCommand(cmd, obj);
	}
	public static CommandWindowPlayAudio AUDIO_DELAY(LayoutScript script, txUIObject obj, float delayTime, SOUND_DEFINE sound, bool loop, float volume)
	{
		CommandWindowPlayAudio cmd = newCmd(out cmd, false, true);
		cmd.mSound = sound;
		cmd.mLoop = loop;
		cmd.mVolume = volume;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	public static CommandWindowPlayAudio AUDIO_DELAY(LayoutScript script, txUIObject obj, float delayTime, SOUND_DEFINE sound, bool loop)
	{
		CommandWindowPlayAudio cmd = newCmd(out cmd, false, true);
		cmd.mSound = sound;
		cmd.mLoop = loop;
		cmd.mUseVolumeCoe = true;
		pushDelayCommand(cmd, obj, delayTime);
		script.addDelayCmd(cmd);
		return cmd;
	}
	#endregion
}