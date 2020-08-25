using System.Collections;
using System.Collections.Generic;

namespace RichUnity.Containers
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list) {
            int count = list.Count;
            int last = count - 1;
            for (int index = 0; index < last; ++index) {
                int randomIndex = UnityEngine.Random.Range(index, count);
                var tmp = list[index];
                list[index] = list[randomIndex];
                list[randomIndex] = tmp;
            }
        }
        
        public static void Shuffle(this IList<int> list) {
            int count = list.Count;
            int last = count - 1;
            for (int index = 0; index < last; ++index) {
                int randomIndex = UnityEngine.Random.Range(index, count);
                int tmp = list[index];
                list[index] = list[randomIndex];
                list[randomIndex] = tmp;
            }
        }
        
        public static void Shuffle(this IList<float> list) {
            int count = list.Count;
            int last = count - 1;
            for (int index = 0; index < last; ++index) {
                int randomIndex = UnityEngine.Random.Range(index, count);
                float tmp = list[index];
                list[index] = list[randomIndex];
                list[randomIndex] = tmp;
            }
        }
    }
}