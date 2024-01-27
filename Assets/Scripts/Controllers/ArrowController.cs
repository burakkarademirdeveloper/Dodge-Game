using System;
using UnityEngine;

namespace Controllers
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;
        private void Start()
        {
            Destroy(gameObject,_destroyTime);
        }
    }
}
