using Gameplay.Player.Running;
using UnityEngine;

namespace Gameplay.Player.FSM.States
{
    public class WalkIdle : State
    {
        [Header("Running Variables:")]
        
        [Tooltip("Model defining the running parameters such as speed and acceleration.")]
        [SerializeField] private RunningModel model;
        
        [Tooltip("Drag applied to the rigidbody when on the ground to control sliding.")]
        [SerializeField] private float groundDrag;

        [Header("Orientation:")]
        
        [Tooltip("Transform representing the player's orientation in the scene.")]
        [SerializeField] private Transform orientation;

        private GroundCheck _groundCheck;
        private Vector3 _moveDirection;
        private Rigidbody _rb;
        
        private bool _shouldBrake;

        public override void OnEnter()
        {
            _rb ??= GetComponent<Rigidbody>();
            _groundCheck ??= GetComponent<GroundCheck>();
            
            _rb.freezeRotation = true;
        }
        public override void OnFixedUpdate()
        {
            
            Move();

            if (_shouldBrake)
            {
                Brake();
            }
            
            SpeedControl();
        }
        
        /// <summary>
        /// Sets the movement direction based on the input direction.
        /// </summary>
        /// <param name="direction">Direction vector from the input.</param>
        public void SetDirection(Vector2 direction)
        {
            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            
            if (direction.magnitude < 0.0001f)
            {
                _shouldBrake = true;
            }

            if (orientation!=null)
            {
                _moveDirection = orientation.forward * moveDirection.z + orientation.right * moveDirection.x;
            }
        }
        
        /// <summary>
        /// Controls the speed of the player based on whether they are on the ground or in the air.
        /// </summary>
        private void SpeedControl()
        {
            _rb.drag = _groundCheck.IsOnGround() ? groundDrag : 0;

            Vector3 flatSpeed = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if (!(flatSpeed.magnitude > model.speed)) return;

            Vector3 limitedSpeed = flatSpeed.normalized * model.speed;
            _rb.velocity = new Vector3(limitedSpeed.x, _rb.velocity.y, limitedSpeed.z);
        }
        
        /// <summary>
        /// Applies a braking force to slow down the player's movement.
        /// </summary>
        private void Brake()
        {
            var currentHorizontalVelocity = _rb.velocity;
            currentHorizontalVelocity.y = 0;

            _rb.AddForce(-currentHorizontalVelocity * model.BrakeMultiplier, ForceMode.Impulse);
            _shouldBrake = false;
        }
        
        /// <summary>
        /// Moves the player by applying a force in the calculated direction.
        /// </summary>
        private void Move()
        {
            if (_groundCheck.IsOnGround())
                _rb.AddForce(_moveDirection.normalized * (model.speed * model.Acceleration), ForceMode.Force);
            else
                _rb.AddForce(_moveDirection.normalized * (model.speed * model.Acceleration * model.AirMultiplier),
                    ForceMode.Force);
        }
    }
}
