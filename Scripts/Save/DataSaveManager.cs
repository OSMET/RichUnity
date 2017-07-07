using System.Linq;
using RichUnity.Save.Data;
using RichUnity.Save.DataLoaderBundles;
using RichUnity.Save.DataLoaders;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.Save {
    public class DataSaveManager : MonoBehaviour {

        public static DataSaveManager Instance;

        public DataLoaderBundle DataLoaderBundle;

        void Awake() {
            if (Instance == null) {
                Instance = this;
            } else if (Instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void Save() {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders) {
                //0 for all scenes
                var sceneNames = dataLoader.SceneNames;
                if (sceneNames.Length == 0 ||sceneNames.Contains(SceneManager.GetActiveScene().name)) {
                    dataLoader.Save();
                }
            }
        }

        public void Load(string sceneName) {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders) {
                //0 for all scenes
                var sceneNames = dataLoader.SceneNames;
                if (sceneNames.Length == 0 || sceneNames.Contains(sceneName)) {
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

        public DL GetDataLoader<DL>() where DL : IDataLoader {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders) {
                if (dataLoader is DL) {
                    return (DL) dataLoader;
                }
            }
            return default(DL);
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
