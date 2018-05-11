using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Toggle))]
    public class AudioToggle : RichAudioSource
    {
        protected override void Awake()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnValueChanged);
            base.Awake();
        }

        private void OnValueChanged(bool value)
        {
            if (value)
            {
                Play();
            }
        }
    }
}