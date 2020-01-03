using System;
using RichUnity.Data;
using UnityEngine;

namespace RichUnity.SaveLoad
{
    public interface ISaveLoadExecutor 
    {
        IData Data { get; }
        
        bool Load();
        void Save();
        void Unload();
        void DeleteSource();
    }

    [Serializable]
    public abstract class SaveLoadExecutor<TData> : ISaveLoadExecutor where TData : IData
    {
        [NonSerialized] // to fix True value set by default
        private bool dataLoaded;

        [SerializeField] 
        private TData data;

        public IData Data
        {
            get
            {
                return data;
            }
        }

        public string JsonData
        {
            get
            {
                return JsonUtility.ToJson(data);
            }

            set
            {
                data = JsonUtility.FromJson<TData>(value);
            }
        }

        public bool Load()
        {
            if (!dataLoaded)
            {
                string typeName = GetType().Name;
                Debug.Log(typeName+ ": begin data loading.");
                if (SourceExists) // if we have a file
                {
                    try // try to load data from it
                    {
                        data = LoadData();
                        Debug.Log(typeName + ": data was loaded");
                        dataLoaded = true;
                    }
                    catch (Exception ex) // oh, you failed to load
                    {
                        Debug.Log(typeName + ": load exception - " + ex);
                        return false;
                    }
                }
                else // no files available -> just use default data values
                {
                    //CreateNewData();
                    
                    dataLoaded = true;
                    Debug.Log(typeName + ": source file does not exist, you will use default values.");
                }
            }

            return true;
        }

//        private void CreateNewData()
//        {
//            try
//            {
//                data = (TData) typeof(TData).GetConstructor(Type.EmptyTypes).Invoke(new object[] { });
//            }
//            catch (NullReferenceException)
//            {
//                throw new ArgumentException(
//                    GetType().Name + ": data must be a class and contain a default constructor.");
//            }
//
//            dataLoaded = true;
//        }

        public void Save()
        {
            bool saved = SaveData(data); // try to save data
            
            if (saved) // successfully saved!
            {
                Debug.Log(GetType().Name + ": data was saved.");
            }
            else //shit happened
            {
                Debug.Log(GetType().Name + ": data was NOT saved.");
            }
        }

        public void Unload()
        {
            if (dataLoaded)
            {
                //data = default(TData);
                dataLoaded = false;
                Debug.Log(GetType().Name + ": data was 'unloaded'.");
            }
        }

        public virtual bool SourceExists
        {
            get
            {
                return true;
            }
        }

        public virtual void DeleteSource()
        {
        }

        public abstract TData LoadData();

        public abstract bool SaveData(TData data);
        

    }
}