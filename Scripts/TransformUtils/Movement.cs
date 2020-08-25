using RichUnity.Math;
using UnityEngine;

namespace RichUnity.TransformUtils
{
    public class Movement
    {
        public bool Active { get; private set; }

        private Transform currentTransform;
        
        private float endPrecision;

        private Transform targetTransform;
        private Vector3 targetPosition;

        public Vector3 TargetPosition
        {
            get
            {
                if (targetTransform)
                {
                    TargetPosition = targetTransform.position;
                }
                return targetPosition;
            }
            set
            {
                if (!AffectsX || !AffectsY || !AffectsZ)
                {
                    var currentPosition = currentTransform.position;
            
                    if (!AffectsX)
                    {
                        value.x = currentPosition.x;
                    }
            
                    if (!AffectsY)
                    {
                        value.y = currentPosition.y;
                    }
            
                    if (!AffectsZ)
                    {
                        value.z = currentPosition.z;
                    }
                }

                targetPosition.Set(value.x, value.y, value.z);
            }
        }

        public bool StopWhenReach;

        public bool AffectsX;
        public bool AffectsY;
        public bool AffectsZ;
        
        private InterpolationTypes interpolationType; // lerp only works with stopWhenReach
        private float lerpTime;
        private Vector3 startPositionOrVelocity;
        
        public void BeginMovement(Transform currentTransform, Vector3 targetPosition,
            InterpolationTypes interpolationType, 
            bool stopWhenReach,
            bool affectsX = true, bool affectsY = true, bool affectsZ = true, 
            float endPrecision = 0.001f)
        {
            this.currentTransform = currentTransform;
            
            this.AffectsX = affectsX;
            this.AffectsY = affectsY;
            this.AffectsZ = affectsZ;

            targetTransform = null;
            
            this.TargetPosition = targetPosition;
            
            this.StopWhenReach = stopWhenReach;
            this.interpolationType = interpolationType;
            this.endPrecision = endPrecision;
            
            Active = true;
            
            if (interpolationType == InterpolationTypes.Lerp)
            {
                lerpTime = 0.0f;
                startPositionOrVelocity = currentTransform.position;
            }
            else if (interpolationType == InterpolationTypes.SmoothDump)
            {
                startPositionOrVelocity.Set(0f, 0f, 0f);
            }
        }
        
        public void BeginMovement(Transform currentTransform, Transform targetTransform,
            InterpolationTypes interpolationType, 
            bool stopWhenReach,
            bool affectsX = true, bool affectsY = true, bool affectsZ = true,
            float endPrecision = 0.001f)
        {
            this.currentTransform = currentTransform;
            
            this.AffectsX = affectsX;
            this.AffectsY = affectsY;
            this.AffectsZ = affectsZ;
            
            this.targetTransform = targetTransform;
            
            this.StopWhenReach = stopWhenReach;
            this.interpolationType = interpolationType;
            this.endPrecision = endPrecision;
            
            Active = true;
            
            if (interpolationType == InterpolationTypes.Lerp)
            {
                lerpTime = 0.0f;
                startPositionOrVelocity = currentTransform.position;
            }
            else if (interpolationType == InterpolationTypes.SmoothDump)
            {
                startPositionOrVelocity.Set(0f, 0f, 0f);
            }
        }

        public void EndMovement()
        {
            Active = false;
        }

        public void Update(float speedOrTime)
        {
            if (Active)
            {
                var currentPosition = currentTransform.position;
                var newPosition = TargetPosition;
     
                if (interpolationType == InterpolationTypes.Lerp)
                {
                    lerpTime += speedOrTime;
                    currentTransform.position = Vector3.Lerp(startPositionOrVelocity, newPosition, lerpTime);
                    
                    //if (System.Math.Abs(lerpTime - 1.0f) < endPrecision)
                    if (newPosition.PrecisionEquals(currentTransform.position, endPrecision)) // todo optimize
                    {

                        if (StopWhenReach)
                        {
                            EndMovement();
                        }
                        else // only works with stopWhenReach but this option can lead to an interesting result
                        {
                            lerpTime = 0.0f;
                        }
                    }
                }
                else if (interpolationType == InterpolationTypes.SmoothDump)
                {
                    currentTransform.position = Vector3.SmoothDamp(currentPosition, newPosition, ref startPositionOrVelocity, speedOrTime);
                    if (newPosition.PrecisionEquals(currentTransform.position, endPrecision))
                    {
                        if (StopWhenReach)
                        {
                            EndMovement();
                        }
                    }
                }
                else
                {
                    currentTransform.position = Vector3.MoveTowards(currentPosition, newPosition, speedOrTime);
                    
                    if (newPosition.PrecisionEquals(currentTransform.position, endPrecision))
                    {
                        if (StopWhenReach)
                        {
                            EndMovement();
                        }
                    }
                }
            }
        }
    }
}