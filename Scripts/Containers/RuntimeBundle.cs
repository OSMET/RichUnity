using UnityEngine;

namespace RichUnity.Containers
{
    [CreateAssetMenu(fileName = "RuntimeBundle", menuName = "Rich Unity/Containers/Runtime Bundle")]
    public class RuntimeBundle : ScriptableObject
    {
        public readonly Bundle Bundle = new Bundle();
    }
}