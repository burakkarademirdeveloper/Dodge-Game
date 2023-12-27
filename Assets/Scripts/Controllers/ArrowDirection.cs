using UnityEngine;

namespace Controllers
{
    public class ArrowDirection : MonoBehaviour
    {
        public void GetDirection(GameObject character)
        {
            var direction = (character.transform.position - transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
