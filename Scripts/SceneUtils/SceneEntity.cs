using System;
using RichUnity.StringUtils;
using UnityEngine;

namespace RichUnity.SceneUtils
{
    
    [Serializable] 
    public class SceneEntity<T>
    {
        public string SearchString;

        public T Value;
            
        [Tooltip("Equals has higher priority.")]
        public StringComparisonWays SceneNameSearchType;
    }
}