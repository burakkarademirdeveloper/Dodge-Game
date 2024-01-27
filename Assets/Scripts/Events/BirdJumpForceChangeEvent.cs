using UnityEngine;

namespace Events
{
    public struct BirdJumpForceChangeEvent
    {
        public readonly float JumpForce;
        public readonly int FirstJump;
        
        public BirdJumpForceChangeEvent(float jumpForce, int firstJump)
        {
            JumpForce = jumpForce;
            FirstJump = firstJump;
        }
    }
}
