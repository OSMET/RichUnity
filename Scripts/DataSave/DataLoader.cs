using System;
using System.Collections.Generic;
using RichUnity.Data;
using UnityEngine;

namespace RichUnity.DataSave {
    public interface IDataLoader {
        bool Load();
        void Save();
        void Unload();
        void DeleteSource();
        IData Data { get; }
        string[] SceneNames { get; }
    }

    [Serializable]
    public abstract class DataLoader<D> : IDataLoader where D : IData {
        [SerializeField]
        private List<string> sceneNames = new List<string>(); //0 for all scenes

        private bool dataLoaded;

        public string[] SceneNames {
            get { return sceneNames.ToArray(); }
        }

        public void AddSceneName(string sceneName) {
            if (!sceneNames.Contains(sceneName)) {
                sceneNames.Add(sceneName);
            }
        }

        public void RemoveSceneName(string sceneName) {
            if (sceneNames.Contains(sceneName)) {
                sceneNames.Remove(sceneName);
            }
        }

        [NonSerialized]
        private D data;

        public IData Data {
            get {
                return data;
            }
        }

        public bool Load() {
            if (!dataLoaded) {
                Debug.Log(GetType().Name + ": begin data loading");
                if (SourceExists) {
                    try {
                        data = LoadData();
                        dataLoaded = true;
                        Debug.Log(GetType().Name + ": data was loaded.");
                    } catch (Exception ex) {
                        Debug.Log(GetType().Name + ": exception - " + ex);
                        return false;
                    }
                } else {
                    CreateNewData();
                    Debug.Log(GetType().Name + ": data was not loaded, default Data object was created.");
                }
            }
            return true;
        }

        private void CreateNewData() {
            try {
                data = (D) typeof(D).GetConstructor(Type.EmptyTypes).Invoke(new object[] {});
            } catch (NullReferenceException) {
                throw new ArgumentException(GetType().Name + ": data must be a class and contain a default constructor.");
            }
            dataLoaded = true;
        }
        
        public void Save() {
            var saved = SaveData(data);
            if (saved) {
                if (dataLoaded) {
                    Debug.Log(GetType().Name + ": data was saved.");
                } else {
                    Debug.Log(GetType().Name + ": data was saved for the first time.");
                }
            } else {
                Debug.Log(GetType().Name + ": data was NOT saved.");
            }
            
        }

        public void Unload() {
            if (dataLoaded) {
                data = default(D);
                dataLoaded = false;
                Debug.Log(GetType().Name + ": data was unloaded.");
            }
        }

        public virtual bool SourceExists {
            get { return true; }
        }

        public virtual void DeleteSource() {
            
        }

        public abstract D LoadData();

        public abstract bool SaveData(D data);
   
    }
}
