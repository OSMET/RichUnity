using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI {
    public class TextFontSwitcher : MonoBehaviour {

        private Text text;
        private int fontSize;
        public Font NewFont;

        public bool IsFontNew {get; private set; }

        public void Awake() {
            text = GetComponent<Text>();
            fontSize = text.fontSize;
        }

        public void SetFont(bool isNew) {
            if ((isNew && !IsFontNew) || (!isNew && IsFontNew)) {
                SwitchFont();
            }
        }

        public void SwitchFont() {
            Font oldFont = text.font;
            text.font = NewFont;
            text.fontSize = fontSize;
            IsFontNew = !IsFontNew;
            NewFont = oldFont;
        }
    }
}
