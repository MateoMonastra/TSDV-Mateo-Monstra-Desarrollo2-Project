using System;
using System.Collections;
using EventSystems.EventSoundManager;
using Player;
using Player.Jump;
using UnityEngine;

namespace Gameplay.FSM.States
{
    public class Jump : State
    {
        public Action Jumped;
        [SerializeField] private JumpModel model;

        [Header("References")] 
        [SerializeField] private EventChannelSoundManager channelSoundManager;
        [SerializeField] private AudioClip clip;
        
        private GroundCheck _groundCheck;
        private bool _canJump;
        private Rigidbody _rb;
        private float _coyoteTimeTimer;

        public override void OnEnter()
        {
            _rb = GetComponent<Rigidbody>();
            _groundCheck = GetComponent<GroundCheck>();
            
            _coyoteTimeTimer = model.CoyoteTime;
            Reset();

            channelSoundManager.PlaySound(clip);
            
            StartCoroutine(OnJump());
        }

        public override void OnUpdate()
        {
            if (!_groundCheck.IsOnGround())
            {
                _coyoteTimeTimer -= Time.deltaTime;
            }
            else
            {
                _coyoteTimeTimer = model.CoyoteTime;
            }
        }

        private IEnumerator OnJump()
        {
            if (!_canJump)
                yield break;

            if (!_groundCheck.IsOnGround() && _coyoteTimeTimer > 0 || _groundCheck.IsOnGround())
            {
                _canJump = false;

                _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

                yield return new WaitForFixedUpdate();
                _rb.AddForce(transform.up * model.JumpForce, ForceMode.Impulse);
                Jumped.Invoke();
                yield return null;
                Invoke(nameof(Reset), model.JumpCooldown);
            }
        }

        private void Reset()
        {
            _canJump = true;
        }
    }
}
