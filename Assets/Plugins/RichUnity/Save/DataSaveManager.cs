using System.Linq;
using Assets.Plugins.RichUnity.Save.Data;
using Assets.Plugins.RichUnity.Save.DataLoaderBundles;
using Assets.Plugins.RichUnity.Save.DataLoaders;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Plugins.RichUnity.Save {
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

        void Start() {
            Load(SceneManager.GetActiveScene().name);
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
