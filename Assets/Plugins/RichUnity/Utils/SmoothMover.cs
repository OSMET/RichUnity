using System.Collections;
using Assets.Plugins.RichUnity.Math;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Utils {
    public class SmoothMover : MonoBehaviour {
        private Coroutine movingCoroutine;
        public Vector3 TargetPosition { get; set; }
        public float SmoothTime;

        public void BeginMoving(bool stopWhenReach = true) {
            StopMoving();
            movingCoroutine = StartCoroutine(Move(stopWhenReach));
        }

        public void StopMoving() {
            if (movingCoroutine != null) {
                StopCoroutine(movingCoroutine);
                movingCoroutine = null;
            }
        }


        private IEnumerator Move(bool stopWhenReach) {
            Vector3 velocity = Vector3.zero;
            while (true) {
                if (Vector3Utils.PrecisionEquals(TargetPosition, transform.position, 0.0001f)) {
                    transform.position = TargetPosition;
                    if (stopWhenReach) {
                        movingCoroutine = null;
                        yield break;
                    }
                } else {
                    Vector3 newPosition = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity, SmoothTime,
                    Mathf.Infinity, Time.smoothDeltaTime);
                    transform.position = newPosition;
                }
                yield return null;
            }
        }
    }
}