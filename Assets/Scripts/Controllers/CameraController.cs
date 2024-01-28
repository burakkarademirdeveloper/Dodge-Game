using System;
using UnityEngine;
using DG.Tweening;
using EventBus;
using Events;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private float _size;
        [SerializeField] private float _duration;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;

        private void OnEnable()
        {
            EventBus<ShakeCameraEvent>.AddListener(ShakeCamera);
        }

        private void OnDisable()
        {
            EventBus<ShakeCameraEvent>.RemoveListener(ShakeCamera);
        }

        private void Start()
        {
            Initial();
        }

        private void Initial()
        {
            _camera = GetComponent<Camera>();
            _camera.orthographicSize = 0f;
            _camera.DOOrthoSize(_size, _duration).OnComplete(((() =>
            {
                GameController.Instance.StartPanel(true);
            })));
        }

        private void ShakeCamera(object sender, ShakeCameraEvent e)
        {
            transform.DOShakePosition(_shakeDuration, _shakeStrength);
        }
    }
}
