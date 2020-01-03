using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Toggle))]
    [RequireComponent(typeof(AudioSource))]
    public class AudioClipToggle : MonoBehaviour
    {
        private AudioSource audioSource;
        
        public AudioClip ToggleOnAudioClip;
        public AudioClip ToggleOffAudioClip;
        
       private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            GetComponent<Toggle>().onValueChanged.AddListener(OnToggleValueChanged);
        }

        protected virtual void OnToggleValueChanged(bool value)
        {
            audioSource.clip = value ? ToggleOnAudioClip : ToggleOffAudioClip;
            audioSource.Play();
        }
    }
}