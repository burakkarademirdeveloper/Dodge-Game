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
        private Vector3 _initialPosition;

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void OnEnable()
        {
            EventBus<BirdRestartPosEvent>.AddListener(RestartGamePosition);
        }

        private void OnDisable()
        {
            EventBus<BirdRestartPosEvent>.RemoveListener(RestartGamePosition);
        }
        private void RestartGamePosition(object sender, BirdRestartPosEvent @event)
        {
            transform.position = _restartPosition;
            transform.DOMove(_initialPosition, _flyTime);
        }
    }
}
