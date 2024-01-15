using System;
using EventBus;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _highScoreText;

        private void OnEnable()
        {
            EventBus<ScoreEvent>.AddListener(GetScores);
        }

        private void OnDisable()
        {
            EventBus<ScoreEvent>.RemoveListener(GetScores);
        }

        private void GetScores(object sender, ScoreEvent e)
        {
            var highScore = GameController.Instance.HighScoreControl();
            _highScoreText.text = highScore.ToString();
        }
    }
}
