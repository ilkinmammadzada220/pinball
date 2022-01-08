using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int health, score;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _resetPos;
    [SerializeField] private Launcher _launcher;

    public delegate void BallDelegate(int health);

    public event BallDelegate OnBallHealthChanged;
    public event BallDelegate OnGetScore;


    private static Ball _instance;
    private int _health = 0;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        score = 0;
        _health = health;
        if (!PlayerPrefs.HasKey("high_score"))
            PlayerPrefs.SetInt("high_score", score);
    }

    public static Ball Instance => _instance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Killer"))
        {
            if (_health == 1)
            {
                GameManager.Instance.FailGame();
            }
            else
            {
                print($"Reset");
                _health--;
                ResetBall();
            }

            OnBallHealthChanged?.Invoke(_health);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ScorePoint"))
            GetScore();
    }

    private void GetScore()
    {
        score += 250;
        if (score > PlayerPrefs.GetInt("high_score"))
            PlayerPrefs.SetInt("high_score", score);
        OnGetScore?.Invoke(score);
    }

    private void ResetBall()
    {
        _rb.position = _resetPos.position;
        _rb.rotation = 0f;
        _rb.velocity = Vector2.zero;

        if (_launcher)
            _launcher.CanLaunch = true;
    }
}