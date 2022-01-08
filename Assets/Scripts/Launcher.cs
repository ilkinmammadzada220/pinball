using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private float _launchForce;
        [SerializeField] private Rigidbody2D _rb;

        private bool _canLaunch = true;

        private void Update()
        {
            if (!_canLaunch) return;

            if (_rb == null) return;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rb.AddForce(Vector2.up * _launchForce);
                _canLaunch = false;
            }
        }

        public bool CanLaunch
        {
            get => _canLaunch;
            set => _canLaunch = value;
        }
    }
}