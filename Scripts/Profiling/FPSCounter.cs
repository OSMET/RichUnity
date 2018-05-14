using RichUnity.Singletons;
using UnityEngine;

namespace RichUnity.Profiling
{
    public class FPSCounter : LazyPersistentSingleton<FPSCounter>
    {
        public float UpdateDelta = 0.5f;
        public Vector2 RightTopCornerScreenPositionFraction = new Vector2(0.15f, 0.15f);
        public Color TextColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        public int FontSize = 30;
        

        private float timeleft;
        private float accumulator;
        private int frames;
        private string text;
        private GUIStyle textStyle;

        private void Start()
        {
            timeleft = UpdateDelta;
        }


        private void OnGUI()
        {
            if (textStyle != null)
            {
                GUI.Label(new Rect(Screen.width - RightTopCornerScreenPositionFraction.x * Screen.width,
                        RightTopCornerScreenPositionFraction.y * Screen.height, Screen.width, textStyle.fontSize), text,
                    textStyle);
            }
        }

        private void Update()
        {
            timeleft -= Time.deltaTime;
            accumulator += Time.timeScale / Time.deltaTime;
            frames++;

            if (timeleft <= 0f)
            {
                textStyle = new GUIStyle
                {
                    alignment = TextAnchor.UpperLeft,
                    fontSize = FontSize,
                    normal = {textColor = TextColor}
                };

                float msec = Time.deltaTime * 1000.0f;
                float fps = accumulator / frames;
                text = string.Format("{0:0.00} FPS\n{1:0.00} ms", fps, msec);

                timeleft = UpdateDelta;
                accumulator = 0.0f;
                frames = 0;
            }
        }
    }
}