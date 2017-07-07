using UnityEngine;

namespace RichUnity.Math {
    public static class Vector2Utils {

        /** Returns the angle in degrees of this vector relative to the x-axis. Angles are towards the positive y-axis (typically
	     *  counter-clockwise) and between 0 and 360. 
         */
        public static float AngleX(Vector2 vector) {
            float angle = AngleXRad(vector) * Mathf.Rad2Deg;
            if (angle < 0) {
                angle += 360;
            }
            return angle;
        }

        /** Returns the angle in radians of this vector (point) relative to the x-axis. Angles are towards the positive y-axis.
	      * (typically counter-clockwise) 
          */
        public static float AngleXRad(Vector2 vector) {
            return Mathf.Atan2(vector.y, vector.x);
        }

        /** Rotates the Vector2 by the given angle, counter-clockwise assuming the y-axis points up.
         * Parameter degrees - the angle in degrees */
        public static Vector2 Rotate(Vector2 vector, float degrees) {
            return RotateRad(vector, degrees * Mathf.Deg2Rad);
        }

        /** Rotates the Vector2 by the given angle, counter-clockwise assuming the y-axis points up.
         * Parameter radians - the angle in radians */
        public static Vector2 RotateRad(Vector2 vector, float radians){
            float cos = Mathf.Cos(radians);
            float sin = Mathf.Sin(radians);

            float newX = vector.x * cos - vector.y * sin;
            float newY = vector.x * sin + vector.y * cos;

            vector.x = newX;
            vector.y = newY;

            return vector;
        }
    }
}
