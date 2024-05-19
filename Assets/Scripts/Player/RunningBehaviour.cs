using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class RunningBehaviour : MonoBehaviour
    {
        [Header("Running Variables: ")] 
        [SerializeField] private float speed;

        [SerializeField] private float acceleration = 10;
        private bool _shouldBrake;

        [SerializeField] private GroundCheck groundCheck;
        [SerializeField] private float groundDrag;

        [Header("Orientation: ")] 
        [SerializeField] private Transform orientation;

        private Vector3 _moveDirection;
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

        private void Update()
        {
            _rb.drag = groundCheck.GroundRay() ? groundDrag : 0;
            SpeedControl();
        }

        private void FixedUpdate()
        {
            _rb.AddForce(_moveDirection.normalized * speed * acceleration, ForceMode.Force);
        }

        private void SpeedControl()
        {
            Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if (flatVel.magnitude > speed)
            {
                Vector3 limitedVel = flatVel.normalized * speed;
                _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
            }
        }
    }
}