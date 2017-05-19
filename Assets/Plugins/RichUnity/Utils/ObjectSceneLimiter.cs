using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Plugins.RichUnity.Utils {
    public class ObjectSceneLimiter : MonoBehaviour {

        public String[] SceneNames;

        public void Awake() {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (!SceneNames.Contains(scene.name)) {
                Destroy(gameObject);
            }
        }

        public void OnDestroy() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }   

    }
}
