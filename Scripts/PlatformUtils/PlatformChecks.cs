namespace RichUnity.PlatformUtils
{
    public static class PlatformChecks
    {
        public static bool DesktopModeOn
        {
            get
            {
                var desktopManager = DesktopManager.Instance;
                var desktopModeOn = true;
                if (desktopManager)
                {
                    desktopModeOn = desktopManager.DesktopModeOn;
                }
                else
                {
                    if (IsMobile)
                    {
                        desktopModeOn = false;
                    }
                }

                return desktopModeOn;
            }
        }

        public static bool IsMobile
        {
            get
            {
                bool isMobile = false;
#if (UNITY_ANDROID || UNITY_IPHONE)
                    isMobile = true;
                #endif
                return isMobile;
            }
        }

        public static bool IsEditor
        {
            get
            {
                bool isEditor = false;
#if UNITY_EDITOR
                isEditor = true;
#endif
                return isEditor;
            }
        }
    }
}