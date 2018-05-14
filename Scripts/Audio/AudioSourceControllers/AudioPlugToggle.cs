using RichUnity.Audio.AudioPlugs;
using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio.AudioSourceControllers
{
    [RequireComponent(typeof(Toggle))]
    public class AudioPlugToggle : AudioSourceController
    {
        public AudioPlug ToggleOnAudioPlug;
        public AudioPlug ToggleOffAudioPlug;

        protected override void Awake()
        {
            base.Awake();
            GetComponent<Toggle>().onValueChanged.AddListener(OnToggleValueChanged);
        }

        protected virtual void OnToggleValueChanged(bool value)
        {
            if (value)
            {
                if (ToggleOnAudioPlug)
                {
                    ToggleOnAudioPlug.Play(AudioSource);
                }
            }
            else
            {
                if (ToggleOffAudioPlug)
                {
                    ToggleOffAudioPlug.Play(AudioSource);
                }
            }
        }
    }
}