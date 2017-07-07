using UnityEngine;

namespace RichUnity.Audio {
    public class AudioManager : MonoBehaviour {
        public static AudioManager Instance = null;

        public AudioSource MusicSource;                
        public bool SoundOn = true;

        public bool MusicOn {
            get {
                return !MusicSource.mute;
            }
            set { MusicSource.mute = !value; }
        }                   

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

    }
}
