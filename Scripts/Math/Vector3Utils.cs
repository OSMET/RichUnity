using UnityEngine;

namespace RichUnity.Math {
    public static class Vector3Utils {
        public static bool PrecisionEquals(Vector3 lhs, Vector3 rhs, float precision) {
            return Vector3.SqrMagnitude(lhs - rhs) < precision;
        }

         /** Returns the angle in degrees of this vector relative to the x-axis. Angles are towards the positive y-axis (typically
	     *  counter-clockwise) and between 0 and 360. 
         */
        public static float AngleX(Vector3 vector) {
            float angle = AngleXRad(vector) * Mathf.Rad2Deg;
            if (angle < 0) {
                angle += 360;
            }
            return angle;
        }

        /** Returns the angle in radians of this vector (point) relative to the x-axis. Angles are towards the positive y-axis.
	      * (typically counter-clockwise) 
          */
        public static float AngleXRad(Vector3 vector) {
            return Mathf.Atan2(vector.y, vector.x);
        }
    }
}
