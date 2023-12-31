namespace Events
{
    public struct BirdAnimEvent
    {
        public readonly string AnimName;

        public BirdAnimEvent(string animName)
        {
            AnimName = animName;
        }
    }
}
