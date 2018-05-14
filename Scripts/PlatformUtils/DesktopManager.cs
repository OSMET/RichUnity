using RichUnity.Singletons;

namespace RichUnity.PlatformUtils {
    public class DesktopManager : PersistentSingleton<DesktopManager> {
        public bool DesktopModeOn;

        protected override void SingletonAwake()
        {
            base.SingletonAwake();
            if (PlatformChecks.IsMobile) {
                DesktopModeOn = false;
            }
        }
    }
}