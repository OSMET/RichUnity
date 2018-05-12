using UnityEngine;

namespace RichUnity.Audio.AudioEvents
{
    [CreateAssetMenu(fileName = "SimpleSingleAudioEvent", menuName = "Audio Events/Simple Single Audio Event")]
    public class SimpleSingleAudioEvent : SimpleAudioEvent
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