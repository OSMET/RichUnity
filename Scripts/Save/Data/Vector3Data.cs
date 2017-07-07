using UnityEngine;

namespace RichUnity.Save.Data {
    [System.Serializable]
    public class Vector3Data : IData {
        public float X;
        public float Y;
        public float Z;

        public Vector3Data() {
        }

        public static implicit operator Vector3(Vector3Data data) {
            return new Vector3(data.X, data.Y, data.Z);
        }

        public void Set(Vector3 obj) {
            X = obj.x;
            Y = obj.y;
            Z = obj.z;
        }

        public static implicit operator Vector3Data(Vector3 obj) {
            return new Vector3Data { X = obj.x, Y = obj.y, Z = obj.z};
        }
    }
}