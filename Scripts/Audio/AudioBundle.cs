using UnityEngine;

namespace RichUnity.Audio {
    /// <summary>
    /// Author: Igor Ponomaryov
    /// </summary>
    [CreateAssetMenu]
    public class AudioBundle : ScriptableObject {
        public AudioClip[] AudioClips;

        public AudioClip GetRandomAudio() {
            if (AudioClips == null || AudioClips.Length == 0) {
                return null;
            }
            return AudioClips[Random.Range(0, AudioClips.Length)];
        }
    }
}