using UnityEngine;

namespace RichUnity.Math
{
    public static class WeightedRandom
    {
        public static int RandomIndex(int[] weights)
        {
            int weightCount = weights.Length;
            int weightSum = 0;
            for (int i = 0; i < weightCount; i++)
            {
                weightSum += weights[i];
            }
            int index = 0;
            while(index < weightCount - 1)
            {
                if (Random.Range(0, weightSum) < weights[index])
                {
                    return index;
                }
                weightSum -= weights[index];
                index++;
            }
            return index;
        }
    }
}