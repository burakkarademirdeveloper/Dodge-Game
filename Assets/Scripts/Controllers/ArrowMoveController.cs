using System;
using UnityEngine;

namespace Controllers
{
    public class ArrowMoveController : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        
        private float _speed;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            Move();
        }
        private void Move()
        {
            var speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
            _rb.velocity = transform.up * speed;
        }
    }
}
