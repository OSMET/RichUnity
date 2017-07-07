using UnityEngine;

namespace RichUnity.Utils {
    [RequireComponent(typeof(GUIText))]
    public class FPSCounter : MonoBehaviour {

        public static FPSCounter Instance;

        public float UpdateDelta = 0.5f;

        private float timeleft;
        private float accumulator;
        private int frames;

        private new GUIText guiText;

        public void Awake() {
            if (Instance == null) {
                Instance = this;
                guiText = GetComponent<GUIText>();
                guiText.enabled = false;
            } else if (Instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void Start() {
            timeleft = UpdateDelta;
        }

        public void OnEnable() {
            if (guiText != null) {
                guiText.enabled = true;
            }
        }

        public void OnDisable() {
            if (guiText != null) {
                guiText.enabled = false;
            }
        }

        public void Update() {
            timeleft -= Time.deltaTime;
            accumulator += Time.timeScale / Time.deltaTime;
            frames++;

            if (timeleft <= 0f) {
                guiText.text = "FPS: " + (accumulator / frames).ToString("f2");
                timeleft = UpdateDelta;
                accumulator = 0.0f;
                frames = 0;
            }
        }


    }
}
