using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Toggle))]
    public class AudioPlugToggle : AudioPlugSource
    {
        private AudioPlug toggleOnAudioPlug;
        public AudioPlug ToggleOffAudioPlug;

        protected override void Awake()
        {
            base.Awake();
            toggleOnAudioPlug = AudioPlug;
            GetComponent<Toggle>().onValueChanged.AddListener(OnToggleValueChanged);
        }

        protected virtual void OnToggleValueChanged(bool value)
        {
            if (value)
            {
                if (toggleOnAudioPlug)
                {
                    AudioPlug = toggleOnAudioPlug;
                    Play();
                }
            }
            else
            {
                if (ToggleOffAudioPlug)
                {
                    AudioPlug = ToggleOffAudioPlug;
                    Play();
                }
            }
        }
    }
}