using UnityEngine;

namespace RichUnity.Save.Data {
    [System.Serializable]
    public class ColorData : IData {
        public float R;
        public float G;
        public float B;
        public float A;

        public ColorData() {
        }

        public static implicit operator Color(ColorData data) {
            return new Color(data.R, data.G, data.B, data.A);
        }

        public void Set(Color obj) {
            R = obj.r;
            G = obj.g;
            B = obj.b;
            A = obj.a;
        }

        public static implicit operator ColorData(Color obj) {
            return new ColorData { R = obj.r, G = obj.g, B = obj.b, A = obj.a};
        }
    }
}