using UnityEngine;

namespace RichUnity.Data
{
    [System.Serializable]
    public class Vector3Data : IData
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3Data()
        {
        }

        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public void Set(Vector3 obj)
        {
            X = obj.x;
            Y = obj.y;
            Z = obj.z;
        }

        public void SetVector(Vector3 obj)
        {
            obj.x = X;
            obj.y = Y;
            obj.z = Z;
        }
    }
}