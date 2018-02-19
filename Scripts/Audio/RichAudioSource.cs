
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
                        ApplyAudioClassMultiplier();
                    }
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
        }

        protected virtual void OnEnable() {
            var audioManager = AudioManager.Instance;
            if (audioManager != null) {
                AudioClass = audioManager.RegisterAudioSource(this);
                ApplyAudioClassMultiplier();
            }
        }
        
        public void ApplyAudioClassMultiplier() {
            audioSource.volume = Volume * AudioClass.Volume;
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
                    ApplyAudioClassMultiplier();
                }
            } else {
                audioSource.volume = volume;
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
