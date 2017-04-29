using UnityEngine;
using UnityEngine.UI;

namespace Assets.Plugins.RichUnity.Audio {
    [RequireComponent(typeof(Button))]
    public class AudioButton : MonoBehaviour {
        public AudioClip OnClickAudioClip;

        public void Start() {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick() {
            AudioManager2D.Instance.PlaySound(OnClickAudioClip);
        }
    }
}
