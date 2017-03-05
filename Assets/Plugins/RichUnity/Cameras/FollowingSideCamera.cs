using UnityEngine;

namespace Assets.Plugins.RichUnity.Cameras {
    [RequireComponent(typeof(Camera))]
    public class FollowingSideCamera : MonoBehaviour {

        public float DampTime;
        public Transform Target;
        public Vector3 Offset;

        private new Camera camera;
        private Vector3 velocity = Vector3.zero;

        
        void Awake() {
            camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void LateUpdate() {
            if (Target) {
                Vector3 targetViewportPosition = camera.WorldToViewportPoint(Target.position);
                Vector3 delta = Target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, targetViewportPosition.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination + Offset, ref velocity, DampTime);
            }
        }
    }
}
