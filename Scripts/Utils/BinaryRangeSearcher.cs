using System.Collections.Generic;
using UnityEngine;

namespace RichUnity.Utils {
    public class BinaryRangeSearcher {
        public int SearchLowerBoundIndex(List<float> values, float value) {
            if (value < values[0]) {
                return -1;
            } else if (value >= values[values.Count - 1]) {
                return values.Count - 1;
            } else {
                int left = 0;
                int right = values.Count;
                int mid;
                while (true) {
                    mid = left + (right - left) / 2;
                    if (Mathf.Abs(value - values[mid]) < 0.000001f || mid == left) {
                        if (mid == right || value < values[left]) {
                            return mid - 1;
                        } else {
                            return mid;
                        }
                    } else {
                        if (value < values[mid]) {
                            right = mid;
                        } else {
                            left = mid + 1;
                        }
                    }
                }
            }
        }
    }
}