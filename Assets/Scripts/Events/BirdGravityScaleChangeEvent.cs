using UnityEngine;

namespace Events
{
    public struct BirdGravityScaleChangeEvent
    {
        public readonly float GravityScale;
        
        public BirdGravityScaleChangeEvent(float gravityScale)
        {
            GravityScale = gravityScale;
        }
    }
}
