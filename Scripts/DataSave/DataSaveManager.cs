using System.Linq;
using RichUnity.Data;
using RichUnity.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.DataSave
{
    public class DataSaveManager : MonoBehaviour
    {
        public DataLoadersBundle DataLoaderBundle;

        public void Save()
        {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders)
            {
                //0 for all scenes
                var sceneNames = dataLoader.SceneNames;
                if (sceneNames.Length == 0 || sceneNames.Contains(SceneManager.GetActiveScene().name))
                {
                    dataLoader.Save();
                }
            }
        }

        public bool Load(string sceneName)
        {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders)
            {
                //0 for all scenes
                var sceneNames = dataLoader.SceneNames;
                if (sceneNames.Length == 0 || sceneNames.Contains(sceneName))
                {
                    var loaded = dataLoader.Load();
                    if (!loaded)
                    {
                        Debug.Log("Some of datas was not loaded");
                        return false;
                    }
                }
                else
                {
                    dataLoader.Unload();
                }
            }

            return true;
        }

        public TData GetData<TData>() where TData : IData
        {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders)
            {
                var data = dataLoader.Data;
                if (data is TData)
                {
                    return (TData) data;
                }
            }

            return default(TData);
        }

        public TDataLoader GetDataLoader<TDataLoader>() where TDataLoader : IDataLoader
        {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders)
            {
                if (dataLoader is TDataLoader)
                {
                    return (TDataLoader) dataLoader;
                }
            }

            return default(TDataLoader);
        }
    }
}