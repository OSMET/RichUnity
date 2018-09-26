using RichUnity.Audio.AudioPlugs;
using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio.AudioSourceControllers
{
    [RequireComponent(typeof(Button))]
    public class AudioPlugButtonClick : AudioSourceController
    {
        public AudioPlug AudioPlug;
        
        protected override void Awake()
        {
            base.Awake();
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        protected virtual void OnButtonClick()
        {
            if (AudioPlug)
            {
                AudioPlug.Play(AudioSource);
            }
        }
    }
}