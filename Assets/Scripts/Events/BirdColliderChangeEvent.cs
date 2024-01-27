using UnityEngine;

namespace Events
{
    public struct BirdColliderChangeEvent
    {
        public readonly bool State;

        public BirdColliderChangeEvent(bool state)
        {
            State = state;
        }
    }
}
