using UnityEngine;

namespace RichUnity.Audio.AudioEvents
{
    [CreateAssetMenu(fileName = "RangedSingleAudioEvent", menuName = "Audio Events/Ranged Single Audio Event")]
    public class RangedSingleAudioEvent : RangedAudioEvent
    {
        [SerializeField]
        private AudioClip audioClip;

        protected override AudioClip AudioClip
        {
            get
            {
                return audioClip;
            }
        }
    }
}