using UnityEngine;

namespace RichUnity.Audio {
    /// <summary>
    /// Author: Igor Ponomaryov
    /// </summary>
    [CreateAssetMenu]
    public class SoundBundle : ScriptableObject {
        public AudioClip[] Clips;

        public AudioClip GetRandomSound() {
            return Clips[Random.Range(0, Clips.Length)];
        }
    }
}