using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIUpdater : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText,_scoreText;

        private void Start()
        {
            Ball.Instance.OnBallHealthChanged += UpdateHealthText;
            Ball.Instance.OnGetScore += UpdateScoreText;
        }

        private void OnDisable()
        {
            Ball.Instance.OnBallHealthChanged -= UpdateHealthText;
            Ball.Instance.OnGetScore -= UpdateScoreText;
        }

        private void UpdateHealthText(int health)
        {
            _healthText.text = health.ToString();
        }

        private void UpdateScoreText(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}