using UnityEngine;

namespace RichUnity.Save.Data {
    [System.Serializable]
    public class Vector2Data : IData {
        public float X;
        public float Y;

        public Vector2Data() {
        }

        public static implicit operator Vector2(Vector2Data data) {
            return new Vector2(data.X, data.Y);
        }

        public void Set(Vector2 obj) {
            X = obj.x;
            Y = obj.y;
        }

        public static implicit operator Vector2Data(Vector2 obj) {
            return new Vector2Data { X = obj.x, Y = obj.y};
        }
    }
}