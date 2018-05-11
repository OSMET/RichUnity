using UnityEngine.Events;

namespace RichUnity.Lerps.Lerpers
{
    public class EventLerper : Lerper
    {
        public UnityEvent OnIncreasingBegan;
        public UnityEvent OnIncreasingEnded;

        public UnityEvent OnDecreasingBegan;
        public UnityEvent OnDecreasingEnded;

        public override void Begin(bool increasing)
        {
            if (increasing)
            {
                if (!Increasing)
                {
                    OnIncreasingBegan.Invoke();
                }
            }
            else
            {
                if (Increasing)
                {
                    OnDecreasingBegan.Invoke();
                }
            }

            base.Begin(increasing);
        }

        public void BeginNoEvent(bool increasing)
        {
            base.Begin(increasing);
        }

        public override void End()
        {
            if (Increasing)
            {
                OnIncreasingEnded.Invoke();
            }
            else
            {
                OnDecreasingEnded.Invoke();
            }

            base.End();
        }

        public void EndNoEvent()
        {
            base.End();
        }
    }
}