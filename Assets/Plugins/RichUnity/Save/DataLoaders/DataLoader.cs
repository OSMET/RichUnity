using System;
using Assets.Plugins.RichUnity.Save.Data;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Save.DataLoaders {
    public interface IDataLoader {
        void Load();
        void Save();
        void Unload();
        IData Data { get; }
        string[] SceneNames { get; }
    }

    [Serializable]
    public abstract class DataLoader<D> : IDataLoader where D : IData {
        [SerializeField]
        private string[] sceneNames; //0 for all scenes

        private bool dataLoaded;

        public string[] SceneNames {
            get { return sceneNames; }
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
                        SaveData(data);
                        Debug.Log(this.GetType().Name + ": data was saved for the first time.");
                    } catch (NullReferenceException ex) {
                        throw new ArgumentException("Data must be a class and contain a default constructor.");
                    }
                }
            }
        }

        public void Save() {
            SaveData(data);
            Debug.Log(this.GetType().Name + ": data was saved.");
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

        public abstract D LoadData();

        public abstract void SaveData(D data);
   
    }
}
