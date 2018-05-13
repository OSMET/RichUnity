using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    public abstract class SimpleAudioPlug : AudioPlug
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
        }
        
        [SerializeField]
        [Range(0.0f, 3.0f)] 
        private float pitch = 1.0f;
        
        public float Pitch
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
            Play(audioSource, audioClip, volume, pitch);
        }
    }
}