using RichUnity.Data;
using UnityEngine;

namespace RichUnity.SaveLoad
{
    public abstract class SaveLoadManager : MonoBehaviour
    {
        protected abstract ISaveLoadExecutor[] SaveLoadExecutors { get; }

        public void SaveAll()
        {
            var saveLoadExecutors = SaveLoadExecutors;
            for (int index = 0; index < saveLoadExecutors.Length; index++)
            {
                saveLoadExecutors[index].Save();
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
                    Debug.Log("Some data was not loaded");
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