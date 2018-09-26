using RichUnity.Audio.AudioPlugs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RichUnity.Audio.AudioSourceControllers
{
    [RequireComponent(typeof(Button))]
    public class AudioPlugButtonHighlight : AudioSourceController, IPointerEnterHandler
    {
        public AudioPlug AudioPlug;

        public void OnPointerEnter(PointerEventData pointerEventData) {
            if (AudioPlug)
            {
                AudioPlug.Play(AudioSource);
            }
        }
    }
}