using System;
using System.Collections;
using EventSystems.EventSoundManager;
using Gameplay.Player.Jump;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Gameplay.Player.FSM.States
{
    public class Jump : State
    {
        public UnityEvent onJumpStart;
        public UnityEvent onJumpEnd;

        [Tooltip("Model defining jump parameters")]
        [SerializeField] private JumpModel model;
        
        private GroundCheck _groundCheck;
        private bool _canJump;
        private Rigidbody _rb;

        public override void OnEnter()
        {
            _rb = GetComponent<Rigidbody>();
            _groundCheck = GetComponent<GroundCheck>();
            
            Reset();

            onJumpStart.Invoke();
            
            StartCoroutine(OnJump());
        }

        public override void OnUpdate()
        { 
        }

        /// <summary>
        /// Coroutine that handles the jump mechanics.
        /// </summary>
        private IEnumerator OnJump()
        {
            if (!_canJump)
                yield break;

            if (!_groundCheck.IsOnGround() || _groundCheck.IsOnGround())
            {
                _canJump = false;

                _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

                yield return new WaitForFixedUpdate();
                _rb.AddForce(transform.up * model.jumpForce, ForceMode.Impulse);
                onJumpEnd.Invoke();
                yield return null;
                Invoke(nameof(Reset), model.JumpCooldown);
            }
        }

        /// <summary>
        /// Resets the ability to jump.
        /// </summary>
        private void Reset()
        {
            _canJump = true;
        }
    }
}
