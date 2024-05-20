using System;
using System.Collections;
using System.Net;
using UnityEngine;

namespace Player
{
    public class JumpBehaviour : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpCooldown;

        private GroundCheck _groundCheck;
        private bool _canJump;
        private Rigidbody _rb;

        private void Start()
        {
            _groundCheck = GetComponent<GroundCheck>();
            _rb = GetComponent<Rigidbody>();
            Reset();
        }

        public IEnumerator Jump()
        {
            if (!_canJump || !_groundCheck.IsOnGround())
                yield break;
            
            _canJump = false;
            
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

            yield return new WaitForFixedUpdate();
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            Invoke(nameof(Reset), jumpCooldown);
        }

        private void Reset()
        {
            _canJump = true;
        }
    }
}