﻿using UnityEngine;

namespace RichUnity.Utils {
    public class FPSCounter : MonoBehaviour {
        public static FPSCounter Instance { get; private set; }

        public float UpdateDelta = 0.5f;

        private float timeleft;
        private float accumulator;
        private int frames;
        private string text;
        private GUIStyle textStyle;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else if (Instance != this) {
                Destroy(gameObject);
            }
        }

        private void Start() {
            timeleft = UpdateDelta;
        }

        
        private void OnGUI() {
            if (textStyle != null) {
                GUI.Label(new Rect(Screen.width - 100, 100, Screen.width, textStyle.fontSize), text, textStyle);
            }
        }

        private void Update() {
            timeleft -= Time.deltaTime;
            accumulator += Time.timeScale / Time.deltaTime;
            frames++;

            if (timeleft <= 0f) {
                textStyle = new GUIStyle {
                    alignment = TextAnchor.UpperLeft,
                    fontSize = Screen.height * 2 / 75,
                    normal = {textColor = new Color(0.0f, 1.0f, 0.0f, 1.0f)}
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
