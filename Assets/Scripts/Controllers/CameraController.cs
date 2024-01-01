using UnityEngine;
using DG.Tweening;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private float _size;
        [SerializeField] private float _duration;
        
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
    }
}
