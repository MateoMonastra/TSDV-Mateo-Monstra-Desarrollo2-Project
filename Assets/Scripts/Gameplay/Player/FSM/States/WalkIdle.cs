using EventSystems.EventSoundManager;
using Player;
using Player.Running;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.FSM.States
{
    public class WalkIdle : State
    {
        [Header("Running Variables: ")] 
        [SerializeField] private RunningModel model;
        [SerializeField] private float groundDrag;
        
        [Header("Orientation: ")] 
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
            SpeedControl();
            
            Move();

            if (_shouldBrake)
            {
                Brake();
            }
        }
        public void SetDirection(Vector2 direction)
        {
            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            
            if (direction.magnitude < 0.0001f)
            {
                _shouldBrake = true;
            }

            _moveDirection = orientation.forward * moveDirection.z + orientation.right * moveDirection.x;
        }
        private void SpeedControl()
        {
            _rb.drag = _groundCheck.IsOnGround() ? groundDrag : 0;

            Vector3 flatSpeed = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if (!(flatSpeed.magnitude > model.speed)) return;

            Vector3 limitedSpeed = flatSpeed.normalized * model.speed;
            _rb.velocity = new Vector3(limitedSpeed.x, _rb.velocity.y, limitedSpeed.z);
        }
        private void Brake()
        {
            var currentHorizontalVelocity = _rb.velocity;
            currentHorizontalVelocity.y = 0;

            _rb.AddForce(-currentHorizontalVelocity * model.BrakeMultiplier, ForceMode.Impulse);
            _shouldBrake = false;
        }
        private void Move()
        {
            if (_groundCheck.IsOnGround())
                _rb.AddForce(_moveDirection.normalized * (model.speed * model.Acceleration), ForceMode.Force);
            else
                _rb.AddForce(_moveDirection.normalized * (model.speed * model.Acceleration * model.AirMultiplayer),
                    ForceMode.Force);
        }
    }
}
