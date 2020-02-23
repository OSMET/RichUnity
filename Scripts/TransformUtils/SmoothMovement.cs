using RichUnity.Math;
using UnityEngine;

namespace RichUnity.TransformUtils
{
    public class SmoothMovement
    {
        public bool Moving { get; private set; }

        private Transform currentTransform;
        private Vector3 targetPosition;
        private Transform targetTransform;

        private bool stopWhenReach;
        private float endPrecision;

        private Vector3 velocity = Vector3.zero;

        public void BeginMoving(Transform currentTransform, Vector3 targetPosition, bool stopWhenReach = true, float endPrecision = 0.0001f)
        {
            this.targetPosition = targetPosition;
            
            this.currentTransform = currentTransform;
            this.stopWhenReach = stopWhenReach;
            this.endPrecision = endPrecision;
            
            Moving = true;
        }
        
        public void BeginMoving(Transform currentTransform, Transform targetTransform, bool stopWhenReach = true, float endPrecision = 0.0001f)
        {
            this.targetTransform = targetTransform;
            
            this.currentTransform = currentTransform;
            this.stopWhenReach = stopWhenReach;
            this.endPrecision = endPrecision;
            
            Moving = true;
        }


        public void StopMoving()
        {
            Moving = false;
            velocity = Vector3.zero;
            targetTransform = null;
        }

        public void Update(float smoothTime)
        {
            var currentPosition = currentTransform.position;
            var targetPosition = targetTransform ? targetTransform.position : this.targetPosition;
            
            if (Moving)
            {
                if (stopWhenReach && targetPosition.PrecisionEquals(currentPosition, endPrecision))
                {
                    StopMoving();
                }
                else
                {
                    currentTransform.position = Vector3.SmoothDamp(currentPosition, targetPosition, ref velocity, smoothTime);
                }
            }
        }
    }
}