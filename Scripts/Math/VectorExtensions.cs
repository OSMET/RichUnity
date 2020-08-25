using UnityEngine;

namespace RichUnity.Math
{
    public static class VectorExtensions
    {
        public static float AngleX(this Vector2 vector)
        {
            float angle = AngleXRad(vector) * Mathf.Rad2Deg;
            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }

        public static float AngleX(this Vector3 vector)
        {
            float angle = AngleXRad(vector) * Mathf.Rad2Deg;
            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }

        public static float AngleXRad(this Vector2 vector)
        {
            return Mathf.Atan2(vector.y, vector.x);
        }

        public static float AngleXRad(this Vector3 vector)
        {
            return Mathf.Atan2(vector.y, vector.x);
        }

        public static Vector2 Rotate(this Vector2 vector, float degrees)
        {
            return RotateRad(vector, degrees * Mathf.Deg2Rad);
        }

        public static Vector2 RotateRad(this Vector2 vector, float radians)
        {
            float cos = Mathf.Cos(radians);
            float sin = Mathf.Sin(radians);

            float newX = vector.x * cos - vector.y * sin;
            float newY = vector.x * sin + vector.y * cos;

            vector.x = newX;
            vector.y = newY;

            return vector;
        }
        
        public static Vector3 Rotate2D(this Vector3 vector, float degrees)
        {
            return RotateRad(vector, degrees * Mathf.Deg2Rad);
        }

        public static Vector3 Rotate2DRad(this Vector3 vector, float radians)
        {
            float cos = Mathf.Cos(radians);
            float sin = Mathf.Sin(radians);

            float newX = vector.x * cos - vector.y * sin;
            float newY = vector.x * sin + vector.y * cos;

            vector.x = newX;
            vector.y = newY;

            return vector;
        }

        public static bool PrecisionEquals(this Vector2 lhs, Vector2 rhs, float precision)
        {
            return FloatSqrMagnitude(lhs - rhs) < precision;
        }

        public static bool PrecisionEquals(this Vector3 lhs, Vector3 rhs, float precision)
        {
            return FloatSqrMagnitude(lhs - rhs) < precision;
        }

        public static bool PrecisionEquals(this Vector4 lhs, Vector4 rhs, float precision)
        {
            return FloatSqrMagnitude(lhs - rhs) < precision;
        }
        
        public static float FloatSqrMagnitude(this Vector2 vector)
        {
            return vector.x * vector.x + vector.y * vector.y;
        }
        
        public static float FloatSqrMagnitude(this Vector3 vector)
        {
            return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
        }
        
        public static float FloatSqrMagnitude(this Vector4 vector)
        {
            return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z + vector.w * vector.w;
        }

        public static Vector2 SetX(this Vector2 vector, float value)
        {
            vector.x = value;
            return vector;
        }

        public static Vector3 SetX(this Vector3 vector, float value)
        {
            vector.x = value;
            return vector;
        }

        public static Vector4 SetX(this Vector4 vector, float value)
        {
            vector.x = value;
            return vector;
        }

        public static Vector2 AddX(this Vector2 vector, float value)
        {
            vector.x += value;
            return vector;
        }
        
        public static Vector3 AddX(this Vector3 vector, float value)
        {
            vector.x += value;
            return vector;
        }
        
        public static Vector4 AddX(this Vector4 vector, float value)
        {
            vector.x += value;
            return vector;
        }

        public static Vector2 SetY(this Vector2 vector, float value)
        {
            vector.y = value;
            return vector;
        }

        public static Vector3 SetY(this Vector3 vector, float value)
        {
            vector.y = value;
            return vector;
        }

        public static Vector4 SetY(this Vector4 vector, float value)
        {
            vector.y = value;
            return vector;
        }
        
        public static Vector2 AddY(this Vector2 vector, float value)
        {
            vector.y += value;
            return vector;
        }
        
        public static Vector3 AddY(this Vector3 vector, float value)
        {
            vector.y += value;
            return vector;
        }
        
        public static Vector4 AddY(this Vector4 vector, float value)
        {
            vector.y += value;
            return vector;
        }

        public static Vector3 SetZ(this Vector3 vector, float value)
        {
            vector.z = value;
            return vector;
        }

        public static Vector4 SetZ(this Vector4 vector, float value)
        {
            vector.z = value;
            return vector;
        }
        
        public static Vector3 AddZ(this Vector3 vector, float value)
        {
            vector.z += value;
            return vector;
        }
        
        public static Vector4 AddZ(this Vector4 vector, float value)
        {
            vector.z += value;
            return vector;
        }

        public static Vector4 SetW(this Vector4 vector, float value)
        {
            vector.w = value;
            return vector;
        }
        
        public static Vector4 AddW(this Vector4 vector, float value)
        {
            vector.w += value;
            return vector;
        }

        public static Vector2 Set(this Vector2 vector, float x, float y)
        {
            vector.x = x;
            vector.y = y;
            return vector;
        }
        
        public static Vector2 Add(this Vector2 vector, float x, float y)
        {
            vector.x += x;
            vector.y += y;
            return vector;
        }

        public static Vector3 Set(this Vector3 vector, float x, float y, float z)
        {
            vector.x = x;
            vector.y = y;
            vector.z = z;
            return vector;
        }
        
        public static Vector3 Add(this Vector3 vector, float x, float y, float z)
        {
            vector.x += x;
            vector.y += y;
            vector.z += z;
            return vector;
        }

        public static Vector4 Set(this Vector4 vector, float x, float y, float z, float w)
        {
            vector.x = x;
            vector.y = y;
            vector.z = z;
            vector.w = w;
            return vector;
        }
        
        public static Vector4 Add(this Vector4 vector, float x, float y, float z, float w)
        {
            vector.x += x;
            vector.y += y;
            vector.z += z;
            vector.w += w;
            return vector;
        }

    }
}