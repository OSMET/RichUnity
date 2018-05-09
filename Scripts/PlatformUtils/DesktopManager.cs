using RichUnity.Singletons;

namespace RichUnity.PlatformUtils {
    public class DesktopManager : PersistentSingleton<DesktopManager> {
        public static DesktopManager Instance { get; private set; }

        public bool DesktopModeOn;

        protected override void OnSingletonAwake()
        {
            base.OnSingletonAwake();
            if (PlatformChecks.IsMobile) {
                DesktopModeOn = false;
            }
        }
    }
}