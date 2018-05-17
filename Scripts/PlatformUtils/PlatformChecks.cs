namespace RichUnity.PlatformUtils
{
    public static class PlatformChecks
    {


        
        public static bool IsStandaloneWin
        {
            get
            {
                bool value = false;
#if UNITY_STANDALONE_WIN
                value = true;
#endif
                return value;
            }
        }        
        
        public static bool IsStandaloneLinux
        {
            get
            {
                bool value = false;
#if UNITY_STANDALONE_LINUX
                value = true;
#endif
                return value;
            }
        }              

        public static bool IsStandalone
        {
            get
            {
                bool value = false;
#if UNITY_STANDALONE
                value = true;
#endif
                return value;
            }
        }
        
        public static bool IsAndroid
        {
            get
            {
                bool value = false;
#if UNITY_ANDROID
                value = true;
#endif
                return value;
            }
        }   
        
        public static bool IsIOS
        {
            get
            {
                bool value = false;
#if UNITY_IOS
                value = true;
#endif
                return value;
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