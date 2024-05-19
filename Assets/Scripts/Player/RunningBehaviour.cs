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
        [SerializeField] private float airMultiplayer;
        [SerializeField] private float brakeMultiplier = .75f;
        private bool _shouldBrake;

        private GroundCheck _groundCheck;
        [SerializeField] private float groundDrag;

        [Header("Orientation: ")] [SerializeField]
        private Transform orientation;

        private Vector3 _moveDirection;
        private Rigidbody _rb;

        private void Start()
        {
            _groundCheck = GetComponent<GroundCheck>();
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
            _rb.drag = _groundCheck.IsOnGround() ? groundDrag : 0;
            SpeedControl();
        }

        private void FixedUpdate()
        {
            if (_groundCheck.IsOnGround())
            {
                _rb.AddForce(_moveDirection.normalized * speed * acceleration, ForceMode.Force);
            }
            else
            {
                _rb.AddForce(_moveDirection.normalized * speed * acceleration * airMultiplayer, ForceMode.Force);
            }
            
            if (_shouldBrake)
            {
                var currentHorizontalVelocity = _rb.velocity;
                currentHorizontalVelocity.y = 0;
                var currentSpeed = currentHorizontalVelocity.magnitude;
                
                _rb.AddForce(-currentHorizontalVelocity * brakeMultiplier, ForceMode.Impulse);
                _shouldBrake = false;
            }
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