using System.Linq;
using RichUnity.Data;
using RichUnity.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.DataSave
{
    public class DataSaveManager : PersistentSingleton<DataSaveManager>
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

        public D GetData<D>() where D : IData
        {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders)
            {
                IData data = dataLoader.Data;
                if (data is D)
                {
                    return (D) data;
                }
            }

            return default(D);
        }

        public DL GetDataLoader<DL>() where DL : IDataLoader
        {
            foreach (var dataLoader in DataLoaderBundle.DataLoaders)
            {
                if (dataLoader is DL)
                {
                    return (DL) dataLoader;
                }
            }

            return default(DL);
        }
    }
}