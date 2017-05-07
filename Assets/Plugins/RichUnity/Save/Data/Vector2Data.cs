using UnityEngine;

namespace Assets.Plugins.RichUnity.Save.Data {
    [System.Serializable]
    public class Vector2Data : IData {
        public float X;
        public float Y;

        public Vector2Data() {
        }

        public static implicit operator Vector2(Vector2Data data) {
            return new Vector2(data.X, data.Y);
        }
    }
}