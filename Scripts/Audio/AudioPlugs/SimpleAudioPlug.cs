using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    public abstract class SimpleAudioPlug : AudioPlug
    {
        [SerializeField]
        [Range(0.0f, 1.0f)] 
        private float volume = 1.0f;

        public override float Volume
        {
            get
            {
                return volume;
            }
        }
        
        [SerializeField]
        [Range(0.0f, 3.0f)] 
        private float pitch = 1.0f;
        
        public override float Pitch
        {
            get
            {
                return pitch;
            }
        }
    }
}