using UnityEngine;

namespace RichUnity.Audio.AudioEvents
{
    public abstract class SimpleAudioEvent : AudioEvent
    {
        protected abstract AudioClip AudioClip { get; }
        
        [SerializeField]
        [Range(0.0f, 1.0f)] 
        private float volume = 1.0f;

        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = Mathf.Clamp(value, 0.0f, 1.0f);;
            }
        }
        
        [SerializeField]
        [Range(-3.0f, 3.0f)] 
        private float pitch = 1.0f;
        
        public float Pitch
        {
            get
            {
                return pitch;
            }

            set
            {
                pitch = Mathf.Clamp(value, -3.0f, 3.0f);
            }
        }
        
        public override void Play(AudioSource audioSource)
        {
            var audioClip = AudioClip;
            if (audioClip == null)
            {
                return;
            }
            Play(audioSource, audioClip, volume, pitch);
        }
    }
}