using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio {
    [RequireComponent(typeof(Button))]
    public class AudioButton : RichAudioSource {

        protected override void Awake() {
            GetComponent<Button>().onClick.AddListener(OnClick);
            base.Awake();
        }

        private void OnClick() {
            Play();
        }
    }
}
