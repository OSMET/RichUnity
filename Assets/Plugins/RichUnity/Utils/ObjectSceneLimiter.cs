using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Plugins.RichUnity.Utils {
    public class ObjectSceneLimiter : MonoBehaviour {

        public String[] SceneNames;

        public virtual void Awake() {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (!SceneNames.Contains(scene.name)) {
                Destroy(gameObject);
            }
        }

        public virtual void OnDestroy() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }   

    }
}
