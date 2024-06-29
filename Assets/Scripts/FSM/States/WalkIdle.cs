using System.Collections.Generic;
using Player;
using Player.Running;
using UnityEngine;
using UnityEngine.Serialization;

namespace FSM.States
{
    public class WalkIdle : global::FSM.States.States
    {
        [Header("Running Variables: ")] 
        [SerializeField] private RunningModel _model;
        
        [SerializeField] private GroundCheck _groundCheck;
        [SerializeField] private float _groundDrag;

        [Header("Orientation: ")] 
        [SerializeField] private Transform _orientation;

        private Vector3 _moveDirection;
        private Rigidbody _rb;

        private bool _shouldBrake;
        public bool Freeze;
        public bool ActiveGun;

        public override void OnEnabled()
        {
            _rb.freezeRotation = true;
        }
        public override void FixedUpdate()
        {
            if (ActiveGun) return;
            
            SpeedControl();
            
            Move();

            if (_shouldBrake)
            {
                Brake();
            }
            
            if (Freeze) _rb.velocity = Vector3.zero;
        }
        public void SetDirection(Vector2 direction)
        {
            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            
            if (direction.magnitude < 0.0001f)
            {
                _shouldBrake = true;
            }

            _moveDirection = _orientation.forward * moveDirection.z + _orientation.right * moveDirection.x;
        }
        private void SpeedControl()
        {
            _rb.drag = _groundCheck.IsOnGround() ? _groundDrag : 0;

            Vector3 flatSpeed = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if (!(flatSpeed.magnitude > _model.Speed)) return;

            Vector3 limitedSpeed = flatSpeed.normalized * _model.Speed;
            _rb.velocity = new Vector3(limitedSpeed.x, _rb.velocity.y, limitedSpeed.z);
        }
        private void Brake()
        {
            var currentHorizontalVelocity = _rb.velocity;
            currentHorizontalVelocity.y = 0;

            _rb.AddForce(-currentHorizontalVelocity * _model.BrakeMultiplier, ForceMode.Impulse);
            _shouldBrake = false;
        }
        private void Move()
        {
            if (_groundCheck.IsOnGround())
                _rb.AddForce(_moveDirection.normalized * (_model.Speed * _model.Acceleration), ForceMode.Force);
            else
                _rb.AddForce(_moveDirection.normalized * (_model.Speed * _model.Acceleration * _model.AirMultiplayer),
                    ForceMode.Force);
        }

        public WalkIdle(List<States> possibleTransitions) : base(possibleTransitions)
        { }
    }
}
