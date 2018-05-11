using RichUnity.Spawners.ObjectPools;
using RichUnity.TimeUtils.Timers;
using UnityEngine;

namespace RichUnity.TimeUtils
{
    public class TimePoolableObject : ObjectPool.PoolableObject
    {
        public Timer PoolTimer;
        public float PoolTimerLimit;

        private void OnPoolTimerEnded()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            PoolTimer.Start();
        }

        protected virtual void Update()
        {
            PoolTimer.Update(Time.deltaTime);
            if (PoolTimer.Time > PoolTimerLimit)
            {
                OnPoolTimerEnded();
            }
        }
    }
}