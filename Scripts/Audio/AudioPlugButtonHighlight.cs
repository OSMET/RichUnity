using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Button))]
    public class AudioPlugButtonHighlight : MonoBehaviour, IPointerEnterHandler
    {
        public AudioPlugSource AudioPlugSource;

        public AudioPlug AudioPlug;
        
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            if (AudioPlugSource != null)
            {
                AudioPlugSource.AudioPlug = AudioPlug;
                
                AudioPlugSource.Play();
            }
        }
    }
}