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
                // Destroy(other.gameObject,1f);
                Destroy(gameObject);
            }
        }
    }
}
