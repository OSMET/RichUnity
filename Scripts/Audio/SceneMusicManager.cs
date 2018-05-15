using System;
using RichUnity.Audio.AudioPlugs;
using RichUnity.Singletons;
using RichUnity.SceneUtils; 
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.Audio
{
    public class SceneMusicManager : PersistentSingleton<SceneMusicManager>
    {
        [Serializable]
        public class SceneMusic : SceneEntity<SimpleAudioPlug>
        {
        }
        
        [SerializeField]
        private SceneMusicSet sceneMusicSet;

        private AudioPlugSource audioPlugSource;

        protected override void SingletonAwake()
        {
            base.SingletonAwake();
            audioPlugSource = gameObject.AddComponent<AudioPlugSource>();
            audioPlugSource.PlayOnAwake = false;
            audioPlugSource.Loop = true;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            var foundSceneMusic = SceneEntityFinder.Find<SceneMusic, SimpleAudioPlug>(sceneMusicSet, scene.name);
            
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

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}