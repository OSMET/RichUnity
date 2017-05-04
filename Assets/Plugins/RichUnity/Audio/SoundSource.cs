
using UnityEngine;

namespace Assets.Plugins.RichUnity.Audio {
    public class SoundSource : MonoBehaviour {
        private AudioSource audioSource;

        public AudioClip SoundClip;

        public void Awake() {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }

        public void PlaySound() {
            PlaySound(1f);
        }
        
        public void PlaySound(float pitch) {
            if (AudioManager.Instance.SoundOn) {
                audioSource.mute = false;
                audioSource.clip = SoundClip;
                audioSource.pitch = pitch;
                audioSource.Play();
            } else {
                audioSource.mute = true;
            }
        }

        public void PlaySoundRandomPitch(float lowPitchRange, float highPitchRange) {
            PlaySound(Random.Range(lowPitchRange, highPitchRange));
        }
    }
}
