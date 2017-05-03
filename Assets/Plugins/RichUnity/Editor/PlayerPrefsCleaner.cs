using UnityEditor;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Editor {
    public class PlayerPrefsCleaner {
        [MenuItem("Utils/Clean PlayerPrefs")]
        static public void CleanPlayerPrefs() {
            PlayerPrefs.DeleteAll();
        }
    }
}
