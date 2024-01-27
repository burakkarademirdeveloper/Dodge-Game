using System;
using EventBus;
using Events;
using UnityEngine;

namespace Controllers
{
    public class ScoreColliderController : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _boxCollider2D;
        
        private void OnEnable()
        {
            EventBus<BirdColliderChangeEvent>.AddListener(ScoreColliderEnableChange);
        }

        private void OnDisable()
        {
            EventBus<BirdColliderChangeEvent>.RemoveListener(ScoreColliderEnableChange);
        }

        private void ScoreColliderEnableChange(object sender, BirdColliderChangeEvent @event)
        {
            _boxCollider2D.enabled = @event.State;
        }
    }
}
