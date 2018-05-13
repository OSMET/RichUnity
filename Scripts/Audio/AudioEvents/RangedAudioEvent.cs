using RichUnity.Scripts.Ranges;
using UnityEngine;

namespace RichUnity.Audio.AudioEvents
{
    public abstract class RangedAudioEvent : AudioEvent
    {
        protected abstract AudioClip AudioClip { get; }
        
        [SerializeField]
        [MinMaxFloatRange(0.0f, 1.0f)] 
        private FloatRange volume = new FloatRange()
        {
            MinValue = 1.0f,
            MaxValue = 1.0f
        };

        public FloatRange Volume
        {
            get
            {
                return volume;
            }
        }
        
        [SerializeField]
        [MinMaxFloatRange(0.0f, 3.0f)] 
        private FloatRange pitch = new FloatRange()
        {
            MinValue = 1.0f,
            MaxValue = 1.0f
        };
        
        public FloatRange Pitch
        {
            get
            {
                return pitch;
            }
        }
        
        public override void Play(AudioSource audioSource)
        {
            var audioClip = AudioClip;
            if (audioClip == null)
            {
                return;
            }
            Play(audioSource, audioClip, volume.RandomValue, pitch.RandomValue);
        }
    }
}