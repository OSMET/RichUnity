using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Button))]
    public class AudioClipButtonClick : MonoBehaviour
    {
        public AudioSource AudioSource;
        
        public AudioClip AudioClip;

        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if (AudioSource != null)
            {
                AudioSource.clip = AudioClip;
                    
                AudioSource.Play();
            }
        }
    }
}