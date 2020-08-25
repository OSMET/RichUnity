using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Button))]
    public class AudioPlugButtonClick : MonoBehaviour
    {
        public AudioPlugSource AudioPlugSource;

        public AudioPlug AudioPlug;
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if (AudioPlugSource)
            {
                AudioPlugSource.AudioPlug = AudioPlug;
                
                AudioPlugSource.Play();
            }
        }
    }
}