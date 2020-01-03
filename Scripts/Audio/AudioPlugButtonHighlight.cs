using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Button))]
    public class AudioPlugButtonHighlight : AudioPlugSource, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            Play();
        }
    }
}