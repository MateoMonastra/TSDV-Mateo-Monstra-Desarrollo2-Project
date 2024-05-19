using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class RunningBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float acceleration = 10;

        [SerializeField] private Transform orientation;

        private Vector3 _moveDirection;

        private bool _shouldBrake;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        public void Move(Vector3 direction)
        {
            if (direction.magnitude < 0.0001f)
            {
                _shouldBrake = true;
            }

            _moveDirection = orientation.forward * direction.z + orientation.right * direction.x;
        }

        private void FixedUpdate()
        {
            _rb.AddForce(_moveDirection.normalized * speed * acceleration, ForceMode.Force);
        }
    }
}