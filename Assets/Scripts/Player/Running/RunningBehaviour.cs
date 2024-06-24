using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Running
{
    public class RunningBehaviour : MonoBehaviour
    {
        [Header("Running Variables: ")] 
        [SerializeField] private RunningModel model;

        private bool _shouldBrake;

        private GroundCheck _groundCheck;
        [SerializeField] private float groundDrag;

        [Header("Orientation: ")] 
        [SerializeField] private Transform orientation;

        private Vector3 _moveDirection;
        private Rigidbody _rb;

        public bool freeze;
        public bool activeGun;

        private void Start()
        {
            _groundCheck = GetComponent<GroundCheck>();
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        public void SetDirection(Vector3 direction)
        {

            if (direction.magnitude < 0.0001f)
            {
                _shouldBrake = true;
            }

            _moveDirection = orientation.forward * direction.z + orientation.right * direction.x;
        }

        private void SpeedControl()
        {
            _rb.drag = _groundCheck.IsOnGround() ? groundDrag : 0;

            Vector3 flatSpeed = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if (!(flatSpeed.magnitude > model.Speed)) return;

            Vector3 limitedSpeed = flatSpeed.normalized * model.Speed;
            _rb.velocity = new Vector3(limitedSpeed.x, _rb.velocity.y, limitedSpeed.z);
        }

        private void FixedUpdate()
        {
            if (activeGun) return;
            
            SpeedControl();
            if (freeze) _rb.velocity = Vector3.zero;

            if (_groundCheck.IsOnGround())
                _rb.AddForce(_moveDirection.normalized * (model.Speed * model.Acceleration), ForceMode.Force);
            else
                _rb.AddForce(_moveDirection.normalized * (model.Speed * model.Acceleration * model.AirMultiplayer),
                    ForceMode.Force);

            if (_shouldBrake)
            {
                Brake();
            }

        }

        private void Brake()
        {
            var currentHorizontalVelocity = _rb.velocity;
            currentHorizontalVelocity.y = 0;

            _rb.AddForce(-currentHorizontalVelocity * model.BrakeMultiplier, ForceMode.Impulse);
            _shouldBrake = false;
        }
    }
}