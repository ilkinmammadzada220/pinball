using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class StartUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _highScoreText;

        private void Start()
        {
            if (!PlayerPrefs.HasKey("high_score"))
                _highScoreText.text = $"0";
            else
                _highScoreText.text = PlayerPrefs.GetInt("high_score").ToString();
        }

        public void OnPlayButtonPressed()
        {
            GameManager.Instance.StartGame();
        }

        public void OnQuitButtonPressed()
        {
            GameManager.Instance.Quit();
        }
    }
}