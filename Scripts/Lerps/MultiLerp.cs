namespace RichUnity.Lerps
{
    public class MultiLerp : Lerp
    {
        public Lerp[] Lerps;

        public override void ChangeValue(float percentage)
        {
            foreach (var lerp in Lerps)
            {
                lerp.ChangeValue(percentage);
            }
        }
    }
}