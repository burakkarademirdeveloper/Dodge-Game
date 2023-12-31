using System;
using EventBus;
using Events;
using UnityEngine;

namespace Controllers
{
    public class BirdAnimController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

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
        }
    }
}
