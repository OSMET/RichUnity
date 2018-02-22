using UnityEngine;

namespace RichUnity.PlatformUtils {
    public class DesktopManager : MonoBehaviour {
        public static DesktopManager Instance { get; private set; }

        public bool DesktopModeOn;

        public void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                if (PlatformChecks.IsMobile) {
                    DesktopModeOn = false;
                }
            } else if (Instance != this) {
                Destroy(gameObject);
            }
        }
    }
}