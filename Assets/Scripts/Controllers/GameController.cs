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
        [SerializeField] private float  _maxGravityScale;
        [SerializeField] private float _minGravityScale;
        
        [Header("UI")]
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _scoreTextGameObject;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TMPro.TextMeshProUGUI _gameOverScoreText;
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;

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
            EventBus<BirdColliderChangeEvent>.Emit(this, new BirdColliderChangeEvent(true));
            EventBus<BirdJumpForceChangeEvent>.Emit(this, new BirdJumpForceChangeEvent(5f,1));
            EventBus<BirdGravityScaleChangeEvent>.Emit(this, new BirdGravityScaleChangeEvent(_maxGravityScale));
            
            SoundController.Instance.PlayTapSound();
            
            SpawnController.Instance.StartSpawn();
            
            StartPanel(false);
            _gameOverPanel.SetActive(false);
            _scoreTextGameObject.SetActive(true);
        }
        public void GameOver()
        {
            //EventBus<BirdColliderChangeEvent>.Emit(this, new BirdColliderChangeEvent(false));
            EventBus<BirdJumpForceChangeEvent>.Emit(this, new BirdJumpForceChangeEvent(0f,0));
            
            SpawnController.Instance.StopSpawn();
            var score = int.Parse(_scoreText.text);
            PlayerPrefs.SetInt("Score", score);
            _gameOverScoreText.text = score.ToString();
            EventBus<ScoreEvent>.Emit(this, new ScoreEvent());
            StartCoroutine(ChangeGravityScale(1f));
        }

        private IEnumerator ChangeGravityScale(float time)
        {
            yield return new WaitForSeconds(time);
            EventBus<BirdGravityScaleChangeEvent>.Emit(this, new BirdGravityScaleChangeEvent(_minGravityScale));
            EventBus<BirdRestartPosEvent>.Emit(this, new BirdRestartPosEvent());
            EventBus<BirdAnimEvent>.Emit(this, new BirdAnimEvent("BirdFly"));
            yield return new WaitForSeconds(time + 1f);
            _gameOverPanel.SetActive(true);
            _scoreTextGameObject.SetActive(false);
            _scoreText.text = "0";
        }
        public void StartPanel(bool state)
        {
            _startPanel.SetActive(state);
            _scoreTextGameObject.SetActive(!state);
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
