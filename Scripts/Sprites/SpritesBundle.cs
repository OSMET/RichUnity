using UnityEngine;

namespace RichUnity.Sprites
{
    /// <summary>
    /// Author: Igor Ponomaryov
    /// </summary>
    [CreateAssetMenu(fileName = "SpritesBundle", menuName = "RichUnity/Sprites/Sprites Bundle")]
    public class SpritesBundle : ScriptableObject
    {
        public Sprite[] Sprites;

        public Sprite GetRandomSprite()
        {
            if (Sprites == null || Sprites.Length == 0)
            {
                return null;
            }

            return Sprites[Random.Range(0, Sprites.Length)];
        }
    }
}