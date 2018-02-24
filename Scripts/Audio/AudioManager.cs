using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RichUnity.Audio {
    public class AudioManager : MonoBehaviour {
        [Serializable]
        public class AudioClass {
            public string Name;
        
            [Range(0.0f, 1.0f)]
            public float Volume;         
            
            public bool Muted;

            public bool UpdateInstantlyOrOnPlay;
        }
        
        public static AudioManager Instance { get; private set; }
        
        [SerializeField]
        private bool masterMuted;
        
        public bool MasterMuted {
            get {
                return masterMuted;
            }
            set {
                if (masterMuted != value) {
                    masterMuted = value;

                    Debug.Log(string.Format("AudioManager: Master Muted Value changed to {0}", value));

                    foreach (var audioClass in AudioClasses) {
                        ApplyAudioClassPropertiesToSources(audioClass);
                    }
                }
            }
        }


        public float MasterVolume {
            get {
                return AudioListener.volume;
            }
            set {
                AudioListener.volume = value;
                Debug.Log(string.Format("AudioManager: Master Volume Value changed to {0}", value));
            }
        }
        
        
        private HashSet<RichAudioSource> audioSources = new HashSet<RichAudioSource>();

        public List<AudioClass> AudioClasses;
        
        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else if (Instance != this) {
                Destroy(gameObject);
            }
        }

        public AudioClass RegisterAudioSource(RichAudioSource audioSource) {
            audioSources.Add(audioSource);
            
            var audioClass = GetAudioClassByName(audioSource.AudioClassName);
//            if (audioClass == null) {
//                audioClass = new AudioClass {
//                    Name = audioSource.AudioClassName,
//                    Volume = 1.0f
//                };
//                AudioClasses.Add(audioClass);
//            }
            return audioClass;
        }
        
        public void UnregisterAudioSource(RichAudioSource audioSource) {
            audioSources.Remove(audioSource);
        }

        public void SetAudioClassVolume(string audioClassName, float volume) {
            var audioClass = GetAudioClassByName(audioClassName);
            if (audioClass != null) {
                volume = Mathf.Clamp01(volume);
                
                if (!Mathf.Approximately(audioClass.Volume, volume)) { //value changed
                    audioClass.Volume = volume;
                    Debug.Log(string.Format("[{0}] AudioClass: Volume Value changed to {1:0.00}", audioClass.Name, volume));
                    ApplyAudioClassPropertiesToSources(audioClass);
                }
            }
        }
        
        public void SetAudioClassMuted(string audioClassName, bool muted) {
            var audioClass = GetAudioClassByName(audioClassName);
            if (audioClass != null) {
                if (audioClass.Muted != muted) { //value changed
                    audioClass.Muted = muted;
                    Debug.Log(string.Format("[{0}] AudioClass: Muted Value changed to {1}", audioClass.Name, muted));
                    ApplyAudioClassPropertiesToSources(audioClass);
                }
            }
        }

        private void ApplyAudioClassPropertiesToSources(AudioClass audioClass) {
            if (audioClass.UpdateInstantlyOrOnPlay) {
                foreach (var audioSource in audioSources.Where(audioSource => audioSource.AudioClass == audioClass)) {
                    audioSource.ApplyAudioManagerProperties(); 
                }
            }
        }

        private AudioClass GetAudioClassByName(string audioClassName) {
            return AudioClasses.Find(ac => ac.Name == audioClassName);
        }
        
        private void OnValidate() {
            for (int i = 0; i < AudioClasses.Count; ++i) {
                var audioClass = AudioClasses[i];
                if (audioClass.Name == "") {
                    audioClass.Name = "Default";
                    audioClass.Volume = 1.0f;
                }
            }
        }
    }
}
