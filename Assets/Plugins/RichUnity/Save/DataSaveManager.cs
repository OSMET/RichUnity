using System.Linq;
using Assets.Plugins.RichUnity.Save.Data;
using Assets.Plugins.RichUnity.Save.DataLoaderBundles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Plugins.RichUnity.Save {
    public class DataSaveManager : MonoBehaviour {

        public static DataSaveManager Instance;

        public DataLoaderBundle DataLoaderBundle;

        void Awake() {
            if (Instance == null) {
                Instance = this;
                Load(SceneManager.GetActiveScene().name);
            } else if (Instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void Save() {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders) {
                //0 for all scenes
                if (dataLoader.SceneNames.Length == 0 || dataLoader.SceneNames.Contains(SceneManager.GetActiveScene().name)) {
                    dataLoader.Save();
                }
            }
        }

        public void Load(string sceneName) {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders) {
                //0 for all scenes
                if (dataLoader.SceneNames.Length == 0 || dataLoader.SceneNames.Contains(sceneName)) {
                    dataLoader.Load();
                } else {
                    dataLoader.Unload();
                }
            }
        }

        public D GetData<D>() where D : IData {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders) {
                IData data = dataLoader.Data;
                if (data is D) {
                    return (D) data;
                }
            }
            return default(D);
        }

        public void OnApplicationQuit() {
            Save();
        }

        void OnApplicationPause(bool pauseStatus) {
            if (pauseStatus) {
                Save();
            }
        }
    }
}
