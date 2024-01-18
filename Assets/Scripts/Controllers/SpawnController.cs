using System;
using System.Collections.Generic;
using EventBus;
using Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnObjects; //There is an object now. I will add more objects later.
        [SerializeField] private float _firstSpawnTime;
        [SerializeField] private float _repeatSpawnTime;

        [SerializeField] private GameObject _particle;
        
        [SerializeField] private GameObject _character;
        
        [SerializeField] private List<GameObject> _spawnPoints;
        
        public static SpawnController Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        private void OnEnable()
        {
            EventBus<ParticleEvent>.AddListener(SpawnParticle);
        }

        private void OnDisable()
        {
            EventBus<ParticleEvent>.RemoveListener(SpawnParticle);
        }

        private void SpawnArrow()
        {
            var randomObj = Random.Range(0, _spawnObjects.Count);
            var randomPoint = Random.Range(0, _spawnPoints.Count);
            var spawnedObject = Instantiate(_spawnObjects[randomObj], _spawnPoints[randomPoint].transform.position, Quaternion.identity);
            
            spawnedObject.GetComponent<ArrowDirection>().GetDirection(_character);
        }
        
        private void SpawnParticle(object sender, ParticleEvent @event)
        {
            var spawnedParticle = Instantiate(_particle, @event.Position, Quaternion.identity);
            Destroy(spawnedParticle, .5f);
        }
        public void StartSpawn()
        {
            InvokeRepeating(nameof(SpawnArrow), _firstSpawnTime, _repeatSpawnTime);
        }
        public void StopSpawn()
        {
            CancelInvoke();
        }
    }
}
