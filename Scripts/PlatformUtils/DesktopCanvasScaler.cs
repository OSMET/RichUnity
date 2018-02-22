using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.PlatformUtils {
    [RequireComponent(typeof(CanvasScaler))]
    public class DesktopCanvasScaler : MonoBehaviour {

        public Vector2 ExtraScale;
        
        private void Start() {
            if (DesktopManager.Instance != null && DesktopManager.Instance.DesktopModeOn) {
                var canvasScaler = GetComponent<CanvasScaler>();
                var referenceResolution = canvasScaler.referenceResolution;
                referenceResolution.x *= ExtraScale.x;
                referenceResolution.y *= ExtraScale.y;
                canvasScaler.referenceResolution = referenceResolution;
            }
        }
    }
}
