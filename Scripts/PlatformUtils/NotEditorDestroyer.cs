using UnityEngine;

namespace RichUnity.PlatformUtils {
    public class NotEditorDestroyer : MonoBehaviour {

        public void Awake() {
            if (!PlatformChecks.IsEditor) {
                Destroy(gameObject);
            }
        }
    }
}
