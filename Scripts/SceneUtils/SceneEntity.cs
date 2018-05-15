using System;
using UnityEngine;

namespace RichUnity.SceneUtils
{
    public enum SceneEntitySearchType
    {
        Equals,
        StartsWith,
        EndsWith,
        Regex
    };
    
    [Serializable] 
    public class SceneEntity<T>
    {
        public string SearchString;

        public T Value;
            
        [Tooltip("Equals has higher priority.")]
        public SceneEntitySearchType SceneNameSearchType;
    }
}