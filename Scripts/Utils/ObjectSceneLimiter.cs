using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.Utils {
    public class ObjectSceneLimiter : MonoBehaviour {
        public String[] SceneNames;

        public virtual void Awake() {
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }

        public virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (!ContainsScene(scene.name)) {
                Destroy(gameObject);
            }
        }

        public bool ContainsScene(string SceneName) {
            return SceneNames.Contains(SceneName);
        }

        public virtual void OnDestroy() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}