using System;
using EventBus;
using Events;
using UnityEngine;

namespace Controllers
{
    public class BirdAnimController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void OnEnable()
        {
            EventBus<BirdAnimEvent>.AddListener(PlayAnimation);
        }

        private void OnDisable()
        {
            EventBus<BirdAnimEvent>.RemoveListener(PlayAnimation);
        }

        private void PlayAnimation(object sender, BirdAnimEvent @event)
        {
            _animator.SetTrigger(@event.AnimName);
            //Invoke(nameof(SpriteRendererEnable),1f);
        }
        private void SpriteRendererEnable()
        {
            _spriteRenderer.enabled = false;
        }
    }
}
