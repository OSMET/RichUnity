using RichUnity.Scripts.Ranges;
using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    public abstract class RangedAudioPlug : AudioPlug
    {
        [SerializeField]
        [MinMaxFloatRange(0.0f, 1.0f)] 
        private FloatRange volumeRange = new FloatRange()
        {
            MinValue = 1.0f,
            MaxValue = 1.0f
        };

        public FloatRange VolumeRange
        {
            get
            {
                return volumeRange;
            }
        }
        
        [SerializeField]
        [MinMaxFloatRange(0.0f, 3.0f)] 
        private FloatRange pitchRange = new FloatRange()
        {
            MinValue = 1.0f,
            MaxValue = 1.0f
        };
        
        public FloatRange PitchRange
        {
            get
            {
                return pitchRange;
            }
        }

        public override float Volume
        {
            get
            {
                return volumeRange.RandomValue;
            }
        }

        public override float Pitch
        {
            get
            {
                return pitchRange.RandomValue;
            }
        }
    }
}