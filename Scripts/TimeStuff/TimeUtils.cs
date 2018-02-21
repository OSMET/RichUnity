namespace RichUnity.TimeStuff {
    public static class TimeUtils {
        public static string FormatHHMMSS(int seconds) {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            seconds = seconds % 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
        
        public static string FormatHHMM(int seconds) {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            return string.Format("{0:D2}:{1:D2}", hours, minutes);
        }
        
        public static string FormatMMSS(int seconds) {
            int minutes = (seconds % 3600) / 60;
            seconds = seconds % 60;
            return string.Format("{0:D2}:{0:D2}", minutes, seconds);
        }
        
        public static string FormatSS(int seconds) {
            seconds = seconds % 60;
            return string.Format("{0:D2}", seconds);
        }
    }
    
}
