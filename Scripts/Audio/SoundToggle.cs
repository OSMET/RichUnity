using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio {
    [RequireComponent(typeof(Toggle))]
    public class SoundToggle : SoundSource {

        public void Start() {
            GetComponent<Toggle>().onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(bool value) {
            if (value) {
                PlaySound();
            }
        }
    }
}
