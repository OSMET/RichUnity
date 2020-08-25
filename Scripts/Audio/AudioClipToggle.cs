using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Toggle))]
    public class AudioClipToggle : MonoBehaviour
    {
        public AudioSource AudioSource;
        
        public AudioClip ToggleOnAudioClip;
        public AudioClip ToggleOffAudioClip;
        
        private void Awake()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnToggleValueChanged);
        }

        protected virtual void OnToggleValueChanged(bool value)
        {
            if (AudioSource != null)
            {
                AudioSource.clip = value ? ToggleOnAudioClip : ToggleOffAudioClip;
                
                AudioSource.Play();
            }
        }
    }
}