using System;
using System.Collections.Generic;
using RichUnity.Save.Data;
using UnityEngine;

namespace RichUnity.Save.DataLoaders {
    public interface IDataLoader {
        void Load();
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

        public void Load() {
            if (!dataLoaded) {
                if (SourceExists) {
                    data = LoadData();
                    dataLoaded = true;
                    Debug.Log(this.GetType().Name + ": data was loaded.");
                } else {
                    try {
                        data = (D) typeof(D).GetConstructor(Type.EmptyTypes).Invoke(new object[] {});
                        //SaveData(data);
                        //Debug.Log(this.GetType().Name + ": data was saved for the first time.");
                        Debug.Log(this.GetType().Name + ": data was not loaded, default Data object was created.");
                    } catch (NullReferenceException ex) {
                        throw new ArgumentException("Data must be a class and contain a default constructor.");
                    }
                }
            }
        }

        public void Save() {
            SaveData(data);
            if (dataLoaded) {
                Debug.Log(this.GetType().Name + ": data was saved.");
            } else {
                Debug.Log(this.GetType().Name + ": data was saved for the first time.");
            }
        }

        public void Unload() {
            if (dataLoaded) {
                data = default(D);
                dataLoaded = false;
                Debug.Log(this.GetType().Name + ": data was unloaded.");
            }
        }

        public virtual bool SourceExists {
            get { return true; }
        }

        public virtual void DeleteSource() {
            
        }

        public abstract D LoadData();

        public abstract void SaveData(D data);
   
    }
}
