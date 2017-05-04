using UnityEngine;
using UnityEngine.UI;

namespace Assets.Plugins.RichUnity.Audio {
    [RequireComponent(typeof(Button))]
    public class SoundButton : SoundSource {

        public void Start() {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick() {
            PlaySound();
        }
    }
}
