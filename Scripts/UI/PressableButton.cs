using UnityEngine.Events;

namespace RichUnity.UI {
    using UnityEngine.UI;

    public class PressableButton : Button {

        public UnityEvent PressEvent;

        private bool pressHappened;

        private void Update() {
            if (!pressHappened) {
                if (IsPressed()) {
                    PressEvent.Invoke();
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