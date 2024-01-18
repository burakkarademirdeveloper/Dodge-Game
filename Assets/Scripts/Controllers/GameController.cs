using System;
using System.Collections;
using EventBus;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        [Header("Bird")]
        [SerializeField] private GameObject _bird;
        [SerializeField] private Rigidbody2D _rb;
        
        [Header("UI")]
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _scoreText;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TMPro.TextMeshProUGUI _gameOverScoreText;

        public static GameController Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject); 
        }

        public void StartGame()
        {
            SpawnController.Instance.StartSpawn();
            _rb.gravityScale = 1f;
            _bird.GetComponent<BirdJumpController>().JumpForce = 5f;
            _bird.GetComponent<BirdJumpController>().FirstJump();
            StartPanel(false);
            _gameOverPanel.SetActive(false);
        }
        public void GameOver()
        {
            var score = Convert.ToInt32(_scoreText.GetComponent<TMPro.TextMeshProUGUI>().text);
            PlayerPrefs.SetInt("Score", score);
            _gameOverScoreText.text = score.ToString();
            EventBus<ScoreEvent>.Emit(this, new ScoreEvent());
            StartCoroutine(ChangeGravityScale(1f));
            _bird.GetComponent<BirdJumpController>().JumpForce = 0f;
            SpawnController.Instance.StopSpawn();
        }

        private IEnumerator ChangeGravityScale(float time)
        {
            yield return new WaitForSeconds(time);
            _rb.gravityScale = 0f;
            EventBus<BirdRestartPosEvent>.Emit(this, new BirdRestartPosEvent());
            EventBus<BirdAnimEvent>.Emit(this, new BirdAnimEvent("BirdFly"));
            yield return new WaitForSeconds(time + 1f);
            _gameOverPanel.SetActive(true);
        }
        public void StartPanel(bool state)
        {
            _startPanel.SetActive(state);
            _scoreText.SetActive(!state);
        }

        public int HighScoreControl()
        {
            var highScore = PlayerPrefs.GetInt("HighScore");
            var score = PlayerPrefs.GetInt("Score");
            
            if (score > highScore)
                PlayerPrefs.SetInt("HighScore", score);
            
            return PlayerPrefs.GetInt("HighScore");
        }
    }
}
