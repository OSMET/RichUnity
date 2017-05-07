using UnityEngine;

namespace Assets.Plugins.RichUnity.Save.Data {
    [System.Serializable]
    public class Vector3Data : IData {
        public float X;
        public float Y;
        public float Z;

        public Vector3Data() {
        }

        public static implicit operator Vector3(Vector3Data data) {
            return new Vector3(data.X, data.Y, data.X);
        }
    }
}