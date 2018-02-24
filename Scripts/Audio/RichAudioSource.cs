
using UnityEngine;

namespace RichUnity.Audio {
    [RequireComponent(typeof(AudioSource))]
    public class RichAudioSource : MonoBehaviour {
        private AudioSource audioSource;

        public string AudioClassName = "Sound";
        
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float volume = 1.0f;
        
        public float Volume {
            get {
                return volume;
            }
            set {
                value = Mathf.Clamp01(value);
 
                if (!Mathf.Approximately(value, volume)) { //value changed
                    volume = value;
                    
                    if (AudioClass != null && AudioClass.UpdateInstantlyOrOnPlay) {
                        ApplyAudioManagerProperties();
                    }
                }
            }
        }
        
        [SerializeField]
        private bool muted;

        public bool Muted {
            get {
                return muted;
            }
            set {
                muted = value;
                
                if (AudioClass != null && AudioClass.UpdateInstantlyOrOnPlay) {
                    ApplyAudioManagerProperties();
                }
            }
        }

        public AudioManager.AudioClass AudioClass { get; private set; }
        
        public AudioSource AudioSource {
            get { return audioSource; }
        }

        protected virtual void Awake() {
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = volume;
            audioSource.mute = muted;
        }

        protected virtual void OnEnable() {
            var audioManager = AudioManager.Instance;
            if (audioManager != null) {
                AudioClass = audioManager.RegisterAudioSource(this);
                ApplyAudioManagerProperties();
            }
        }
        
        public void ApplyAudioManagerProperties() {
            audioSource.volume = Volume * AudioClass.Volume;

            var newMuted = muted || AudioClass.Muted;

            var audioManager = AudioManager.Instance;
            if (audioManager != null) {
                newMuted = newMuted || audioManager.MasterMuted;
            }
            
            audioSource.mute = newMuted;
        }
        
        protected virtual void OnDisable() {
            var audioManager = AudioManager.Instance;
            if (audioManager != null) {
                audioManager.UnregisterAudioSource(this);
                AudioClass = null;
            }
        }

        public void Play() {
            if (AudioClass != null) {
                if (!AudioClass.UpdateInstantlyOrOnPlay) {
                    ApplyAudioManagerProperties();
                }
            } else {
                audioSource.volume = volume;
                audioSource.mute = muted;
            }
            audioSource.Play();
        }
        
        public void Stop() {
            audioSource.Stop();
        }

        public void SetRandomPitch(float lowPitchRange = 0f, float highPitchRange = 1f) {
            audioSource.pitch = Random.Range(lowPitchRange, highPitchRange);
        }
    }
}
