using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnObjects; //There is an object now. I will add more objects later.
        [SerializeField] private float _firstSpawnTime;
        [SerializeField] private float _repeatSpawnTime;

        [SerializeField] private GameObject _character;
        private void Start()
        {
            InvokeRepeating(nameof(SpawnArrow), _firstSpawnTime, _repeatSpawnTime);
        }

        private void SpawnArrow()
        {
            var randomIndex = Random.Range(0, _spawnObjects.Count);
            var spawnedObject = Instantiate(_spawnObjects[randomIndex], transform.position, Quaternion.identity);
            
            spawnedObject.GetComponent<ArrowDirection>().GetDirection(_character);
        }
    }
}
