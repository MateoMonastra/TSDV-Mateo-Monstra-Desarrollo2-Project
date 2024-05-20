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

        public bool freeze;
        public bool activeGun;

        private void Start()
        {
            _groundCheck = GetComponent<GroundCheck>();
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        public void Move(Vector3 direction)
        {
            if (activeGun) return;
            
            if (direction.magnitude < 0.0001f)
            {
                _shouldBrake = true;
            }

            _moveDirection = orientation.forward * direction.z + orientation.right * direction.x;
        }

        private void Update()
        {
            _rb.drag = _groundCheck.IsOnGround() && !activeGun ? groundDrag : 0;
            SpeedControl();

            if (freeze) _rb.velocity = Vector3.zero;
        }

        private void FixedUpdate()
        {
            if (activeGun) return;
     
            if (_groundCheck.IsOnGround())
            {
                _rb.AddForce(_moveDirection.normalized * (speed * acceleration), ForceMode.Force);
            }
            else
            {
                _rb.AddForce(_moveDirection.normalized * (speed * acceleration * airMultiplayer), ForceMode.Force);
            }
            
            if (_shouldBrake)
            {
                var currentHorizontalVelocity = _rb.velocity;
                currentHorizontalVelocity.y = 0;
                
                _rb.AddForce(-currentHorizontalVelocity * brakeMultiplier, ForceMode.Impulse);
                _shouldBrake = false;
            }
        }

        private void SpeedControl()
        {
            if (activeGun) return;
            
            Vector3 flatSpeed = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            if (flatSpeed.magnitude > speed)
            {
                Vector3 limitedSpeed = flatSpeed.normalized * speed;
                _rb.velocity = new Vector3(limitedSpeed.x, _rb.velocity.y, limitedSpeed.z);
            }
        }
    }
}