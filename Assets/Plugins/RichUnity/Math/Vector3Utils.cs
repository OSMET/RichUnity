using UnityEngine;

namespace Assets.Plugins.RichUnity.Math {
    public static class Vector3Utils {
        public static bool PrecisionEquals(Vector3 lhs, Vector3 rhs, float precision) {
            return Vector3.SqrMagnitude(lhs - rhs) < precision;
        }
    }
}
