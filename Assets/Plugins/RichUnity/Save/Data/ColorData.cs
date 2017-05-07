using UnityEngine;

namespace Assets.Plugins.RichUnity.Save.Data {
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
    }
}