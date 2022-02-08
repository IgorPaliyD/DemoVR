using UnityEngine;
using Liquid.Core;

namespace Liquid.Utils
{
    public class PositionProceduralAnimator : SimpleProceduralAnimator
    {
        protected override void UpdateTransform(Direction direction, float t)
        {
            this.transform.localPosition = GetLerpedValue(direction, t);
        }

        protected override void SetValue(out Vector3 value)
        {
            value = this.transform.localPosition;
        }

        protected virtual Vector3 GetLerpedValue(Direction direction, float t)
        {
            switch (direction)
            {
                case Direction.Forward:
                return Vector3.Lerp(m_beginValue, m_endValue, t);
                case Direction.Backward:
                return Vector3.Lerp(m_endValue, m_beginValue, t);
                default: return Vector3.zero;
            }
        }
    }
}