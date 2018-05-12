using UnityEngine;

namespace RichUnity.Audio.AudioEvents
{
    [CreateAssetMenu(fileName = "SimpleMultiAudioEvent", menuName = "Audio Events/Simple Multi Audio Event")]
    public class SimpleMultiAudioEvent: SimpleAudioEvent
    { 
        [SerializeField]
        private AudioClip[] audioClips;

        protected override AudioClip AudioClip
        {
            get
            {
                return audioClips.Length == 0 ? null : audioClips[Random.Range(0, audioClips.Length)];
            }
        }
    }
}