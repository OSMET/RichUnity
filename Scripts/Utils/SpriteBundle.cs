using UnityEngine;

namespace RichUnity.Utils {
    /// <summary>
    /// Author: Igor Ponomaryov
    /// </summary>
    [CreateAssetMenu]
    public class SpriteBundle : ScriptableObject {
        public Sprite[] Sprites;

        public Sprite GetRandomSprite() {
            return Sprites[Random.Range(0, Sprites.Length)];
        }
    } 
}
