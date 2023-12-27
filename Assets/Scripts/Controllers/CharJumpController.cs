using UnityEngine;

namespace Controllers
{
    public class CharJumpController : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
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
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
