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
                    Instance.MusicSource.mute = MusicSource.mute;
                    Instance.MusicSource.bypassEffects = MusicSource.bypassEffects;
                    Instance.MusicSource.bypassListenerEffects = MusicSource.bypassListenerEffects;
                    Instance.MusicSource.bypassReverbZones = MusicSource.bypassReverbZones;
                    Instance.MusicSource.playOnAwake = MusicSource.playOnAwake;
                    
                    Instance.MusicSource.priority = MusicSource.priority;
                    Instance.MusicSource.volume = MusicSource.volume;
                    Instance.MusicSource.pitch = MusicSource.pitch;
                    Instance.MusicSource.panStereo = MusicSource.panStereo;
                    Instance.MusicSource.spatialBlend = MusicSource.spatialBlend;
                    Instance.MusicSource.reverbZoneMix = MusicSource.reverbZoneMix;

                    Instance.MusicSource.dopplerLevel = MusicSource.dopplerLevel;
                    Instance.MusicSource.spread = MusicSource.spread;
                    Instance.MusicSource.rolloffMode = MusicSource.rolloffMode;
                    Instance.MusicSource.minDistance = MusicSource.minDistance;
                    Instance.MusicSource.maxDistance = MusicSource.maxDistance;

                    if (MusicSource.playOnAwake) {
                        Instance.PlayMusic(MusicSource.clip);
                    }
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
