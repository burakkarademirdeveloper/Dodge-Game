using UnityEngine;

namespace Controllers
{
    public class BirdJumpController : MonoBehaviour
    {
        public float JumpForce;
        private Rigidbody2D _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            CharacterJump();
        }
        private void CharacterJump()
        {
            if (Input.GetMouseButtonDown(0))
                _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
