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
                EventBus<BirdJumpForceChangeEvent>.Emit(this, new BirdJumpForceChangeEvent(5f, 1));
                GameController.Instance.GameOver();
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
