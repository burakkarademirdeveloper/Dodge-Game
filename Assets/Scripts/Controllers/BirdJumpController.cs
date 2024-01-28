using UnityEngine;

namespace Controllers
{
    public class BirdJumpController : MonoBehaviour
    {
        [HideInInspector] public float JumpForce;
        [SerializeField] private Rigidbody2D _rb;
        
        private void Update()
        {
            BirdJump();
        }
        private void BirdJump()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

                if (JumpForce != 0)
                {
                    SoundController.Instance.PlayTapSound();
                }
            }
        }
        
        public void FirstJump()
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
