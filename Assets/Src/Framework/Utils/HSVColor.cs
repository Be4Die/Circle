using UnityEngine;

namespace Framework.Utils
{
    public struct HSVColor
    {
        public float H;
        public float V;
        public float S;
        public HSVColor(Color color)
        {
            Color.RGBToHSV(color, out H, out S, out V);
        }
        public HSVColor(float h, float v, float s)
        {
            H = h;
            V = v;
            S = s;
        }

        public Color ToColor() => Color.HSVToRGB(H, S, V);

        public override string ToString() => $"({H}, {S}, {V})";
    }
}
