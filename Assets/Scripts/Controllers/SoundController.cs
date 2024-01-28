using System;
using UnityEngine;

namespace Controllers
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _gameOver;
        [SerializeField] private AudioSource _tapSound;
        [SerializeField] private AudioSource _bgSound;

        public static SoundController Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void PlayGameOverSound()
        {
            _gameOver.Play();
        }
        public void PlayTapSound()
        {
            _tapSound.Play();
        }
    }
}
