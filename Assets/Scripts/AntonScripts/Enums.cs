using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Liquid.Core
{
    public enum Axis
    {
        X = 0,
        Y = 1, 
        Z = 2
    }

    public enum ControllerType
    {
        LeftController = 0,
        RightController = 1,
        Both = 2,
        Undefided = 3
    }

    public enum ControllerState 
    {
        Undefined = 0, 
        Free = 1,
        Interacts = 2,
        HoldAnItem = 3,
        Teleporting = 4,
        Clench = 5,
        Animating = 6,
        InteractsUI = 7
    }

    public enum PlayerState
    {
        Undefined = 0,
        Free = 1,
        Immobilized = 2
    }

    public enum IterationType
    {
        Cyclic = 0,
        Single = 1,
        PingPong = 2
    }

    public enum Direction 
    {
        Forward = 0,
        Backward = 1
    }

    public enum CoordinateSystem
    {
        Local = 0,
        Global = 1
    }

    public enum UpdatingState
    {
        Update = 0,
        FixedUpdate = 1,
        LateUpdate = 2,
        UpdateByTime = 3
    }

    public static class AxisVector3
    {
        public static readonly Vector3 X = Vector3.right;
        public static readonly Vector3 Y = Vector3.up;
        public static readonly Vector3 Z = Vector3.forward;
        public static Vector3 GetAxisVector(Axis axis)
        {
            switch (axis)
            {
                case Axis.X:
                return X;
                case Axis.Y:
                return Y;
                case Axis.Z:
                return Z;
                default:
                return Vector3.zero;
            }
        }
    }
}