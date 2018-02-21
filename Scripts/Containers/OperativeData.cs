using UnityEngine;

namespace RichUnity.Containers {
    public class OperativeData : MonoBehaviour {
        public static OperativeData Instance { get; private set; }

        public Bundle Data { get; private set; }

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                Data = new Bundle();
                DontDestroyOnLoad(gameObject);
            } else if (Instance != this) {
                Destroy(gameObject);
            }
        }
    }
}
