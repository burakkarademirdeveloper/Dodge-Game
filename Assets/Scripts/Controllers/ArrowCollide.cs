using EventBus;
using Events;
using UnityEngine;

namespace Controllers
{
    public class ArrowCollide : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<BirdJumpController>())
            {
                EventBus<BirdAnimEvent>.Emit(this, new BirdAnimEvent("BirdFire"));
                EventBus<BirdColliderChangeEvent>.Emit(this, new BirdColliderChangeEvent(false));
                EventBus<BirdJumpForceChangeEvent>.Emit(this, new BirdJumpForceChangeEvent(5f, 1));
                GameController.Instance.GameOver();
                SoundController.Instance.PlayGameOverSound();
                Destroy(gameObject);
            }

            if (other.GetComponent<ArrowCollide>())
            {
                EventBus<ParticleEvent>.Emit(this, new ParticleEvent(transform.position));
                Destroy(gameObject);
            }
        }
    }
}
