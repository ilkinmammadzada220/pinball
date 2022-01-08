using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    public void Move(float force)
    {
        if (_rb != null)
        {
            _rb.AddForce(Vector2.up * force);
        }
    }
}