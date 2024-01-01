using UnityEngine;

namespace Events
{
    public struct ParticleEvent
    {
        public Vector3 Position;

        public ParticleEvent(Vector3 position)
        {
            Position = position;
        }
    }
}
