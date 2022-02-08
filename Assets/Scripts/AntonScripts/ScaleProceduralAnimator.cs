using UnityEngine;
using Liquid.Core;

namespace Liquid.Utils
{
    public class ScaleProceduralAnimator : SimpleProceduralAnimator
    {
        protected override void UpdateTransform(Direction direction, float t)
        {
            this.transform.localScale = GetLerpedValue(direction, t);
        }

        protected override void SetValue(out Vector3 value)
        {
            value = this.transform.localScale;
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