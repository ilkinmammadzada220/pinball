using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            if(Instance != null)
                Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        

        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void FailGame()
        {
            SceneManager.LoadScene("Start");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}