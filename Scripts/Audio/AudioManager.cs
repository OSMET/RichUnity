using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RichUnity.Audio {
    public class AudioManager : MonoBehaviour {
        [Serializable]
        public class AudioClass {
            public string Name;
        
            [SerializeField]
            [Range(0.0f, 1.0f)]
            private float volume;
            
            public float Volume {
                get {
                    return volume;
                }
                set {
                    volume = value;                    
                }
            }
            public bool UpdateInstantlyOrOnPlay;
        }
        
        
        
        public static AudioManager Instance { get; private set; }
        
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float masterVolume = 1.0f;
        
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
                    if (audioClass.UpdateInstantlyOrOnPlay) {
                        var audioSourcesToUpdate = audioSources.Where(audioSource => audioSource.AudioClass == audioClass).ToArray();
                        foreach (var audioSource in audioSourcesToUpdate) {
                            audioSource.ApplyAudioClassMultiplier(); 
                        }
                    }
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
