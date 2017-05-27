
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
            PlaySound(1f, 1f);
        }
        
        public void PlaySound(float pitch = 1f, float volume = 1f) {
            if (AudioManager.Instance.SoundOn) {
                audioSource.mute = false;
                audioSource.clip = SoundClip;
                audioSource.volume = volume;
                audioSource.pitch = pitch;
                audioSource.Play();
            } else {
                audioSource.mute = true;
            }
        }

        public void PlaySoundRandomPitch() {
            PlaySoundRandomPitch(0f, 1f, 1f);
        }

        public void PlaySoundRandomPitch(float lowPitchRange = 0f, float highPitchRange = 1f, float volume = 1f) {
            PlaySound(Random.Range(lowPitchRange, highPitchRange), volume);
        }
    }
}
