using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.UI {
    public class TextFontSwitcher : MonoBehaviour {

        public Font NewFont;

        public bool IsFontNew {get; private set; }

        public void Awake() {
        }

        public void SetFont(bool isNew) {
            if ((isNew && !IsFontNew) || (!isNew && IsFontNew)) {
                SwitchFont();
            }
        }

        public void SwitchFont() {
            Text text =  GetComponent<Text>();
            var oldFontSize = text.fontSize;
            Font oldFont = text.font;
            text.font = NewFont;
            text.fontSize = oldFontSize;
            IsFontNew = !IsFontNew;
            NewFont = oldFont;
        }
    }
}
