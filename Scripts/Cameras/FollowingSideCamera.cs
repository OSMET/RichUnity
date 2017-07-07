using UnityEngine;

namespace RichUnity.Cameras {
    [RequireComponent(typeof(Camera))]
    public class FollowingSideCamera : MonoBehaviour {

        public float DampTime;
        public Transform Target;
        public Vector3 Offset;

        private new Camera camera;
        private Vector3 velocity = Vector3.zero;

        public bool FixedX;
        public bool FixedY;

        
        void Awake() {
            camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void LateUpdate() {
            if (Target) {
                Vector3 targetViewportPosition = camera.WorldToViewportPoint(Target.position);
                Vector3 delta = Target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, targetViewportPosition.z));
                Vector3 destination = transform.position + delta;
                if (FixedX) {
                    destination.x = transform.position.x;
                }
                if (FixedY) {
                    destination.y = transform.position.y;
                }
                transform.position = Vector3.SmoothDamp(transform.position, destination + Offset, ref velocity, DampTime);
            }
        }
    }
}
