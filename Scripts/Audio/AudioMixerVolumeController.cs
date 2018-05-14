using UnityEngine;
using UnityEngine.Audio;

namespace RichUnity.Audio
{
    [CreateAssetMenu(fileName = "AudioMixerVolumeController", menuName = "Rich Unity/Audio/Audio Mixer Volume Controller")]
    public class AudioMixerVolumeController : ScriptableObject
    {
        [SerializeField]
        private AudioMixer audioMixer;

        public AudioMixer AudioMixer
        {
            get
            {
                return audioMixer;
            }
        }

        public string VolumeParameterName;

        private const float LowerVolumeBound = -80.0f;
        private const float UpperVolumeBound = 20.0f;

        public float Volume
        {
            get
            {
                if (muted)
                {
                    return volumeBeforeMute;
                }
                else
                {
                    return VolumeNoMutedGuards;
                }
            }
            set
            {
                float newVolumeT = Mathf.Clamp01(value);
                if (muted)
                {
                    volumeBeforeMute = newVolumeT;
                }
                else
                {
                    VolumeNoMutedGuards = newVolumeT;
                }
            }
        }

        private float VolumeNoMutedGuards
        {
            get
            {
                float volume = 0.0f;
                if (AudioMixer)
                {
                    AudioMixer.GetFloat(VolumeParameterName, out volume);
                }

                volume = Mathf.InverseLerp(LowerVolumeBound, UpperVolumeBound, volume);
                return volume;
            }

            set
            {
                if (AudioMixer)
                {
                    AudioMixer.SetFloat(VolumeParameterName,
                        Mathf.Lerp(LowerVolumeBound, UpperVolumeBound, value));
                }
            }
        }

        private bool muted;
        private float volumeBeforeMute;

        public bool Muted
        {
            get
            {
                return muted;
            }
            set
            {
                muted = value;
                if (muted)
                {
                    volumeBeforeMute = VolumeNoMutedGuards;
                    VolumeNoMutedGuards = 0.0f;
                }
                else
                {
                    VolumeNoMutedGuards = volumeBeforeMute;
                }
            }
        }

        private void OnEnable()
        {
            muted = false;
        }
    }
}