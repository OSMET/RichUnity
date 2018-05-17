using RichUnity.Singletons;
using UnityEngine;

namespace RichUnity.PlatformUtils
{
    public class DesktopManager : PersistentSingleton<DesktopManager>
    {
        [SerializeField]
        private bool desktopModeOn;

        public static bool DesktopModeOn
        {
            get
            {
                return Instance != null ? Instance.desktopModeOn : PlatformChecks.IsStandalone;
            }
        }
    }
}