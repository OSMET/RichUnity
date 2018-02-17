using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.Utils {
    public class SceneLimitedObject : MonoBehaviour {
        [Tooltip("Leave the array empty to disable limits.")]
        public String[] SceneNames;

        protected virtual void Awake() {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (SceneNames.Length > 0 && !SceneNames.Contains(scene.name)) {
                Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}