using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio.AudioSourceControllers
{
    [RequireComponent(typeof(Button))]
    public class AudioClipButtonClick : AudioSourceController
    {
        protected override void Awake()
        {
            base.Awake();
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        protected virtual void OnButtonClick()
        {
            AudioSource.Play();
        }
    }
}