using UnityEngine;

namespace RichUnity.PlatformUtils
{
    public class NotEditorDestroyer : MonoBehaviour
    {
        private void Awake()
        {
            if (!PlatformChecks.IsEditor)
            {
                Destroy(gameObject);
            }
        }
    }
}