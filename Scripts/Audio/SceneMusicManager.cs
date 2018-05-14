using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using RichUnity.Audio.AudioPlugs;
using RichUnity.Containers;
using RichUnity.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.Audio
{
    public class SceneMusicManager : PersistentSingleton<SceneMusicManager>
    {
        public enum SceneNameSearchType
        {
            Equals,
            StartsWith,
            EndsWith,
            Regex
        };
        
        [Serializable]
        public class SceneMusic
        {
            public string SearchString;
            public SimpleAudioPlug SimpleAudioPlug;
            [Tooltip("Equals has higher priority.")]
            public SceneNameSearchType SceneNameSearchType;
        }

        [CreateAssetMenu(fileName = "SceneMusicSet", menuName = "Rich Unity/Audio/Scene Music Set")]
        public class SceneMusicSet : RuntimeSet<SceneMusic>
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
            var foundSceneMusic = sceneMusicSet.Find(sceneMusic =>
                sceneMusic.SceneNameSearchType == SceneNameSearchType.Equals && scene.name.Equals(sceneMusic.SearchString));
            

            if (foundSceneMusic == null)
            {
                foundSceneMusic = sceneMusicSet.Find(sceneMusic =>
                {
                    if (sceneMusic.SceneNameSearchType == SceneNameSearchType.StartsWith)
                    {
                        return scene.name.StartsWith(sceneMusic.SearchString);
                    }
                    if (sceneMusic.SceneNameSearchType == SceneNameSearchType.EndsWith)
                    {
                        return scene.name.EndsWith(sceneMusic.SearchString);
                    }
                    if (sceneMusic.SceneNameSearchType == SceneNameSearchType.Regex)
                    {
                        return Regex.IsMatch(scene.name, sceneMusic.SearchString);
                    }
                    return false;
                });
            }
            
            if (foundSceneMusic != null)
            {
                if (audioPlugSource.AudioPlug != foundSceneMusic.SimpleAudioPlug)
                {
                    audioPlugSource.AudioPlug = foundSceneMusic.SimpleAudioPlug;
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