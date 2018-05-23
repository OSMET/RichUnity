using RichUnity.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace RichUnity.SaveLoad
{
    public class SaveLoadManager : MonoBehaviour
    {
        public SaveLoadExecutorsBundle SaveLoadExecutorBundle;

        public void Save()
        {
            for (int index = 0; index < SaveLoadExecutorBundle.SaveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = SaveLoadExecutorBundle.SaveLoadExecutors[index];
//0 for all scenes
                var sceneNames = saveLoadExecutor.SceneNames;

                if (sceneNames.Length == 0 || sceneNames.Contains(SceneManager.GetActiveScene().name))
                {
                    saveLoadExecutor.Save();
                }
            }
        }

        public bool Load(string sceneName)
        {
            for (int index = 0; index < SaveLoadExecutorBundle.SaveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = SaveLoadExecutorBundle.SaveLoadExecutors[index];
//0 for all scenes
                var sceneNames = saveLoadExecutor.SceneNames;
                if (sceneNames.Length == 0 || sceneNames.Contains(sceneName))
                {
                    var loaded = saveLoadExecutor.Load();
                    if (!loaded)
                    {
                        Debug.Log("Some of datas was not loaded");
                        return false;
                    }
                }
                else
                {
                    saveLoadExecutor.Unload();
                }
            }

            return true;
        }

        public TData GetData<TData>() where TData : IData
        {
            for (int index = 0; index < SaveLoadExecutorBundle.SaveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = SaveLoadExecutorBundle.SaveLoadExecutors[index];
                var data = saveLoadExecutor.Data;
                if (data is TData)
                {
                    return (TData) data;
                }
            }

            return default(TData);
        }

        public TSaveLoadExecutor GetSaveLoadExecutor<TSaveLoadExecutor>() where TSaveLoadExecutor : ISaveLoadExecutor
        {
            for (int index = 0; index < SaveLoadExecutorBundle.SaveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = SaveLoadExecutorBundle.SaveLoadExecutors[index];
                if (saveLoadExecutor is TSaveLoadExecutor)
                {
                    return (TSaveLoadExecutor) saveLoadExecutor;
                }
            }

            return default(TSaveLoadExecutor);
        }
    }
}