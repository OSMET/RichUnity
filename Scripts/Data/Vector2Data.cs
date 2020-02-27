using UnityEngine;

namespace RichUnity.Data
{
    [System.Serializable]
    public class Vector2Data : IData
    {
        public float X;
        public float Y;

        public Vector2Data()
        {
        }

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public void Set(Vector2 obj)
        {
            X = obj.x;
            Y = obj.y;
        }

        public void SetVector(Vector2 obj)
        {
            obj.x = X;
            obj.y = Y;
        }
    }
}