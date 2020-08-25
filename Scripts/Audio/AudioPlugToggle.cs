using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Toggle))]
    public class AudioPlugToggle : MonoBehaviour
    {
        public AudioPlugSource AudioPlugSource;
        
        public AudioPlug ToggleOnAudioPlug;
        public AudioPlug ToggleOffAudioPlug;

        private void Awake()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool value)
        {
            if (AudioPlugSource!= null)
            {
                AudioPlugSource.AudioPlug = value ? ToggleOnAudioPlug : ToggleOffAudioPlug;
                
                AudioPlugSource.Play();
            }
        }
    }
}