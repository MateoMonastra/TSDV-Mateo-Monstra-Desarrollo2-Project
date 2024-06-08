using System.Collections;
using UnityEngine;

namespace Player.Jump
{
    public class JumpBehaviour : MonoBehaviour
    {
        public Coroutine OnPlay;

        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpCooldown;
        [SerializeField] private float coyoteTime;

        private GroundCheck _groundCheck;
        private bool _canJump;
        private Rigidbody _rb;
        private float _coyoteTimeTimer;

        private void Start()
        {
            _coyoteTimeTimer = coyoteTime;
            _groundCheck = GetComponent<GroundCheck>();
            _rb = GetComponent<Rigidbody>();
            Reset();
        }

        private void Update()
        {
            if (!_groundCheck.IsOnGround())
            {
                _coyoteTimeTimer -= Time.deltaTime;
            }
            else
            {
                _coyoteTimeTimer = coyoteTime;
            }
        }

        public IEnumerator Jump()
        {
            if (!_canJump)
                yield break;

            if (!_groundCheck.IsOnGround() && _coyoteTimeTimer > 0 || _groundCheck.IsOnGround())
            {
                _canJump = false;

                _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

                yield return new WaitForFixedUpdate();
                _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

                Invoke(nameof(Reset), jumpCooldown);
            }
        }

        private void Reset()
        {
            _canJump = true;
        }
    }
}