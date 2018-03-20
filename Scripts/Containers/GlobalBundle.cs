using UnityEngine;

namespace RichUnity.Containers {
    public class GlobalBundle : MonoBehaviour {
        public static GlobalBundle Instance { get; private set; }

        public Bundle Bundle { get; private set; }

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                Bundle = new Bundle();
                DontDestroyOnLoad(gameObject);
            } else if (Instance != this) {
                Destroy(gameObject);
            }
        }
    }
}
