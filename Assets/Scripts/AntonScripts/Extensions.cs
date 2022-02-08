using UnityEngine;

namespace Liquid.Core
{
    public static class Extensions
    {
        public static Vector3 LerpAngle(Vector3 a, Vector3 b, float t)
        {
            var x = Mathf.LerpAngle(a.x, b.x, t);
            var y = Mathf.LerpAngle(a.y, b.y, t);
            var z = Mathf.LerpAngle(a.z, b.z, t);
            return new Vector3(x, y, z);
        }
    }
}