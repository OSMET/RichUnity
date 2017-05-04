
using UnityEngine;

namespace Assets.Plugins.RichUnity.Audio {
    public class SoundSource : MonoBehaviour {
        public AudioClip OnClickAudioClip;

        public void PlaySound() {
            AudioManager2D.Instance.PlaySound(OnClickAudioClip);
        }
    }
}
