using System;
using UnityEngine;
using DG.Tweening;
using EventBus;
using Events;

namespace Controllers
{
    public class BirdController : MonoBehaviour
    {
        [SerializeField] private Vector3 _restartPosition;
        [SerializeField] private float _flyTime;
        [SerializeField] private BoxCollider2D _boxCollider;
        [SerializeField] private BirdJumpController _jumpController;
        [SerializeField] private Rigidbody2D _rb;
        private Vector3 _initialPosition;

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void OnEnable()
        {
            EventBus<BirdRestartPosEvent>.AddListener(RestartGamePosition);
            EventBus<BirdColliderChangeEvent>.AddListener(ColliderEnableChange);
            EventBus<BirdJumpForceChangeEvent>.AddListener(ChangeJumpForce);
            EventBus<BirdGravityScaleChangeEvent>.AddListener(ChangeGravityScale);
        }

        private void OnDisable()
        {
            EventBus<BirdRestartPosEvent>.RemoveListener(RestartGamePosition);
            EventBus<BirdColliderChangeEvent>.RemoveListener(ColliderEnableChange);
            EventBus<BirdJumpForceChangeEvent>.RemoveListener(ChangeJumpForce);
            EventBus<BirdGravityScaleChangeEvent>.RemoveListener(ChangeGravityScale);
        }
        private void RestartGamePosition(object sender, BirdRestartPosEvent @event)
        {
            transform.position = _restartPosition;
            transform.DOMove(_initialPosition, _flyTime);
        }

        private void ColliderEnableChange(object sender, BirdColliderChangeEvent @event)
        {
            _boxCollider.enabled = @event.State;
        }
        private void ChangeJumpForce(object sender, BirdJumpForceChangeEvent @event)
        {
            _jumpController.JumpForce = @event.JumpForce;
            
            var firstJump = @event.FirstJump;
            
            if (firstJump == 1)
                _jumpController.FirstJump();
        }
        private void ChangeGravityScale(object sender, BirdGravityScaleChangeEvent @event)
        {
            _rb.gravityScale = @event.GravityScale;
        }
    }
}
