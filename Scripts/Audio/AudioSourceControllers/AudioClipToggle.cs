using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio.AudioSourceControllers
{
    [RequireComponent(typeof(Toggle))]
    public class AudioClipToggle : AudioSourceController
    {
        public AudioClip ToggleOnAudioClip;
        public AudioClip ToggleOffAudioClip;
        
        protected override void Awake()
        {
            base.Awake();
            GetComponent<Toggle>().onValueChanged.AddListener(OnToggleValueChanged);
        }

        protected virtual void OnToggleValueChanged(bool value)
        {
            AudioSource.clip = value ? ToggleOnAudioClip : ToggleOffAudioClip;

            AudioSource.Play();
        }
    }
}