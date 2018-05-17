using UnityEngine;

namespace RichUnity.PlatformUtils
{
    public class DesktopActivator : MonoBehaviour
    {
        public bool ActiveOnDesktop;

        private void Awake()
        {
            gameObject.SetActive(DesktopManager.DesktopModeOn && ActiveOnDesktop);
        }
    }
}