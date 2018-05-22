using UnityEngine;

namespace RichUnity.SaveLoad
{
    public abstract class SaveLoadExecutorsBundle : MonoBehaviour
    {
        public abstract ISaveLoadExecutor[] SaveLoadExecutors { get; }
    }
}