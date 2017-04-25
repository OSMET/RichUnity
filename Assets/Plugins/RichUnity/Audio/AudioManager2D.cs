using UnityEngine;

namespace Assets.Plugins.RichUnity.Audio {
    public class AudioManager2D : MonoBehaviour {
        public static AudioManager2D Instance = null;

        public AudioSource MusicSource;                
        public AudioSource SoundSource;                   

        void Awake() {
            if (Instance == null) {
                Instance = this;
            } else if (Instance != this) {
                if (Instance.MusicSource.clip != MusicSource.clip) {
                    Instance.PlayMusic(MusicSource.clip);
                }
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void PlayMusic(AudioClip musicClip) {
            MusicSource.clip = musicClip;
            MusicSource.Play();
        }

        public void PlaySound(AudioClip soundClip, float pitch = 1f) {
            SoundSource.clip = soundClip;
            SoundSource.pitch = pitch;
            SoundSource.Play();
        }

        public void PlaySoundRandomPitch(AudioClip soundClip, float lowPitchRange, float highPitchRange) {
            PlaySound(soundClip, Random.Range(lowPitchRange, highPitchRange));
        }
    }
}
