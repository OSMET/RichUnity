using System;
using RichUnity.SceneUtils; 
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.Audio
{
    public class SceneMusicManager : MonoBehaviour// PersistentSingleton<SceneMusicManager>
    {
        [Serializable]
        public class SceneMusic : SceneEntity<AudioPlug>
        {
        }
        
        [SerializeField]
        private SceneMusicSet sceneMusicSet;

        private AudioPlugSource audioPlugSource;

        protected virtual void Awake()
        {
            audioPlugSource = gameObject.AddComponent<AudioPlugSource>();
            audioPlugSource.PlayOnAwake = false;
            audioPlugSource.Loop = true;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            var foundSceneMusic = SceneEntityFinder.Find<SceneMusic, AudioPlug>(sceneMusicSet, scene.name);
            
            if (foundSceneMusic != null)
            {
                if (audioPlugSource.AudioPlug != foundSceneMusic.Value)
                {
                    audioPlugSource.AudioPlug = foundSceneMusic.Value;
                    audioPlugSource.Play();
                }
            }
            else
            {
                audioPlugSource.Stop();
                audioPlugSource.AudioPlug = null;
            }
        }

        protected virtual void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}