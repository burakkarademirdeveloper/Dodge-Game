using System;
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
        
        [SerializeField] SpawnController _spawnController;

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
            _spawnController.gameObject.SetActive(true);
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
            _spawnController.gameObject.SetActive(false);
            Invoke(nameof(ChangeGravityScale),1f);
            _gameOverPanel.SetActive(true);
            _bird.GetComponent<BirdJumpController>().JumpForce = 0f;
        }

        private void ChangeGravityScale(float value)
        {
            _rb.gravityScale = value;
        }
        
        public void RestartGame() //RestartButton
        {
            //Kuş y2 ye gider. -- Oklar fırlatılmaya başlar. -- Puan sıfırlanır. -- Restart butonu kaybolur.
            var birdPos = new Vector3(0f,2f,0f);
            
            _rb.gravityScale = 0f;
            _bird.transform.position = birdPos;
            EventBus<BirdAnimEvent>.Emit(this, new BirdAnimEvent("BirdFire"));
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
