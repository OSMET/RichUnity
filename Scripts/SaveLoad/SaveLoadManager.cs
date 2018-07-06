using RichUnity.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using RichUnity.SceneUtils;

namespace RichUnity.SaveLoad
{
    public abstract class SaveLoadManager : ScriptableObject
    {
        public abstract ISaveLoadExecutor[] SaveLoadExecutors { get; }

        public void Save()
        {
            var saveLoadExecutors = SaveLoadExecutors;
            string activeSceneName = SceneManager.GetActiveScene().name;
            for (int index = 0; index < saveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = saveLoadExecutors[index];
//"" for all scenes
                var sceneSearchString = saveLoadExecutor.SceneSearchString;

                if (sceneSearchString.Equals("") || SceneEntityFinder.CompareBySearchType(activeSceneName, sceneSearchString, saveLoadExecutor.SceneNameSearchType))
                {
                    saveLoadExecutor.Save();
                }
            }
        }

        public bool Load(string sceneName)
        {
            var saveLoadExecutors = SaveLoadExecutors;
            string activeSceneName = SceneManager.GetActiveScene().name;

            for (int index = 0; index < saveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = saveLoadExecutors[index];
//"" for all scenes
                var sceneSearchString = saveLoadExecutor.SceneSearchString;

                if (sceneSearchString.Equals("") || SceneEntityFinder.CompareBySearchType(activeSceneName, sceneSearchString, saveLoadExecutor.SceneNameSearchType))
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
            var saveLoadExecutors = SaveLoadExecutors;
            for (int index = 0; index < saveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = saveLoadExecutors[index];
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
            var saveLoadExecutors = SaveLoadExecutors;
            for (int index = 0; index < saveLoadExecutors.Length; index++)
            {
                var saveLoadExecutor = saveLoadExecutors[index];
                if (saveLoadExecutor is TSaveLoadExecutor)
                {
                    return (TSaveLoadExecutor) saveLoadExecutor;
                }
            }

            return default(TSaveLoadExecutor);
        }
    }
}