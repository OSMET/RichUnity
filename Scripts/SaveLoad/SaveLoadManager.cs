using RichUnity.Data;
using UnityEngine;

namespace RichUnity.SaveLoad
{
    public abstract class SaveLoadManager : MonoBehaviour
    {
        protected abstract ISaveLoadExecutor[] SaveLoadExecutors { get; }

        public bool SaveAll()
        {
            var saveLoadExecutors = SaveLoadExecutors;
            bool dataLoaded = true;
            for (int index = 0; index < saveLoadExecutors.Length; index++)
            {
                if (!saveLoadExecutors[index].DataLoaded)
                {
                    dataLoaded = false;
                    break;
                }
            }

            if (dataLoaded)
            {
                for (int index = 0; index < saveLoadExecutors.Length; index++)
                {
                    bool saved = saveLoadExecutors[index].Save();
                    if (!saved)
                    {
                        Debug.Log("Some data wasn't saved. The saving process is stopped.");
                        return false;
                    }
                } 
                return true;
            }
            else
            {
                Debug.Log("Some data is not loaded. The saving process is stopped.");
                return false;
            }
        }

        public bool LoadAll()
        {
            var saveLoadExecutors = SaveLoadExecutors;
            for (int index = 0; index < saveLoadExecutors.Length; index++)
            {
                bool loaded = saveLoadExecutors[index].Load();
                if (!loaded)
                {
                    Debug.Log("Some data wasnt't saved loaded.");
                    return false;
                }
            }

            return true;
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

       
    }
}