using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Button))]
    public class AudioPlugButtonClick : AudioPlugSource
    {
        protected override void Awake()
        {
            base.Awake();
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        protected virtual void OnButtonClick()
        {
            Play();
        }
    }
}