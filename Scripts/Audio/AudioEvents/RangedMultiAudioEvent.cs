using UnityEngine;

namespace RichUnity.Audio.AudioEvents
{
    [CreateAssetMenu(fileName = "RangedMultiAudioEvent", menuName = "Audio Events/Ranged Multi Audio Event")]
    public class RangedMultiAudioEvent: RangedAudioEvent
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