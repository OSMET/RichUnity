using RichUnity.SceneUtils; 
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RichUnity.Audio
{
    public class SceneMusicManager : MonoBehaviour// PersistentSingleton<SceneMusicManager>
    {
        [SerializeField]
        private SceneMusicSet sceneMusicSet;

        private AudioPlugSource audioPlugSource;

        private void Awake()
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

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}