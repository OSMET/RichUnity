using UnityEngine;

namespace RichUnity.Data
{
    [System.Serializable]
    public class ColorData : IData
    {
        public float R;
        public float G;
        public float B;
        public float A;

        public ColorData()
        {
        }

        public Color ToColor()
        {
            return new Color(R, G, B, A);
        }

        public void Set(Color obj)
        {
            R = obj.r;
            G = obj.g;
            B = obj.b;
            A = obj.a;
        }

        public void SetColor(Color obj)
        {
            obj.r = R;
            obj.g = G;
            obj.b = B;
            obj.a = A;
        }
    }
}