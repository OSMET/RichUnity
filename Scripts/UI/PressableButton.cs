using UnityEngine.Events;

namespace RichUnity.UI {
    using UnityEngine.UI;

    public class PressableButton : Button {

        public UnityEvent PressEvent;

        private bool pressHappened;

        public void Update() {
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