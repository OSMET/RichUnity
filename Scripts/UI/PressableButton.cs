using UnityEngine.Events;

namespace RichUnity.UI {
    using UnityEngine.UI;

    public class PressableButton : Button {

        public UnityEvent OnPress;

        private bool pressHappened;

        public void Update() {
            if (!pressHappened) {
                if (IsPressed()) {
                    OnPress.Invoke();
                    pressHappened = true;
                }
            } else {
                if (!IsPressed()) {
                    pressHappened = false;
                }
            }
        }

    }
}