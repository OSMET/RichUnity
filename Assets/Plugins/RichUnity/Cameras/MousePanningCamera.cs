using UnityEngine;

namespace Assets.Plugins.RichUnity.Cameras {

    [RequireComponent(typeof(Camera))]
    public class MousePanningCamera : MonoBehaviour {

        public float MouseSensitivity = 1f;

        public Vector2 UpperBorder;
        public Vector2 LowerBorder;

        public bool FixedX;
        public bool FixedY;

        private Vector3 lastPosition;
        private new Camera camera;

        void Awake() {
            camera = GetComponent<Camera>();
        }

        void Update() {

            if (enabled) {

                if (Input.GetMouseButtonDown(0)) {
                    lastPosition = Input.mousePosition;
                }

                if (Input.GetMouseButton(0)) {
                    if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                        return;

                    Vector3 delta = Input.mousePosition - lastPosition;
                    Vector3 translate = new Vector3 {
                        x = FixedX ? 0f : -delta.x * MouseSensitivity,
                        y = FixedY ? 0f : -delta.y * MouseSensitivity,
                        z = 0f
                    };


                    Vector3 newPosition = transform.position + translate;

                    Vector3 screenHalfSizeWorld =
                        camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -transform.position.z)) -
                        camera.transform.position;

                    if (!FixedX) {
                        if (newPosition.x - screenHalfSizeWorld.x < LowerBorder.x) {
                            newPosition.x = LowerBorder.x + screenHalfSizeWorld.x;
                        } else if (newPosition.x + screenHalfSizeWorld.x > UpperBorder.x) {
                            newPosition.x = UpperBorder.x - screenHalfSizeWorld.x;
                        }
                    }
                    if (!FixedY) {
                        if (newPosition.y - screenHalfSizeWorld.y < LowerBorder.y) {
                            newPosition.y = LowerBorder.y + screenHalfSizeWorld.y;
                        } else if (newPosition.y + screenHalfSizeWorld.y > UpperBorder.y) {
                            newPosition.y = UpperBorder.y - screenHalfSizeWorld.y;
                        }
                    }
                    transform.position = newPosition;
                    lastPosition = Input.mousePosition;
                }
            }
        }
    }
}
