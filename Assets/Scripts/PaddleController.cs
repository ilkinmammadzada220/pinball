using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private Paddle _leftPaddle, _rightPaddle;
    [SerializeField] private float _paddleForce;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _leftPaddle.Move(_paddleForce);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _rightPaddle.Move(_paddleForce);
    }
}
