using System;
using System.Collections;
using EventSystems.EventSoundManager;
using Guns.Swing;
using Player;
using Player.Running;
using Unity.VisualScripting;
using UnityEngine;
using State = Gameplay.FSM.States.State;

namespace Gameplay.FSM.States
{
    public class Swing : State
    {
        [Header("References")] 
        
        [SerializeField] private Transform playerCamera;
        [SerializeField] private LineRenderer lr;
        [SerializeField] private Transform gunTip;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator animator;
        [SerializeField] private string swingAnimationName;
        
        [Header("Audio SFX:")] 
        
        [SerializeField] private EventChannelSoundManager channel;
        [SerializeField] private AudioClip shootClip;
        [SerializeField] private AudioClip hitClip;

        [Header("Model")] 
        
        [SerializeField] private SwingModel model;

        private float _swingCdTimer;
        private bool _grappling;

        private Vector3 _swingPoint;
        private SpringJoint _joint;


        public override void OnEnter()
        {
            StartSwing();
        }
        public override void OnUpdate()
        {
        }
        public override void OnEnd()
        {
            StopSwing();
        }
        public override void OnLateUpdate()
        {
            if (!_joint) return;
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, _swingPoint);
        }
        private void StartSwing()
        {
            if (_joint) StopSwing();
            
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, model.MaxSwingDistance,
                    model.Grappeable))
            {
                animator.SetBool(swingAnimationName, true);
                
                _swingPoint = hit.point;

                ExecuteSwing();
                Debug.Log("Swing");
            }
            else
            {
                _swingPoint = playerCamera.position + playerCamera.forward * model.MaxSwingDistance;
                Invoke(nameof(StopSwing), model.SwingDelayTime);
            }

            lr.enabled = true;
        }
        private void ExecuteSwing()
        {
            channel.OnPlaySound(hitClip);
          
            _joint = transform.AddComponent<SpringJoint>();
            _joint.autoConfigureConnectedAnchor = false;
            _joint.connectedAnchor = _swingPoint;

            float distanceFromPoint = Vector3.Distance(playerCamera.position, _swingPoint);

            _joint.maxDistance = distanceFromPoint * model.MaxDistance;
            _joint.minDistance = distanceFromPoint * model.MinDistance;

            _joint.spring = model.Spring;
            _joint.damper = model.Damper;
            _joint.massScale = model.MassScale;
            
            lr.positionCount = 2;
            
        }
        private void StopSwing()
        {
            animator.SetBool(swingAnimationName, false);
            
            if (_joint) Destroy(_joint);
            
            lr.positionCount = 0;
            _swingCdTimer = model.SwingCd;
        }
    }
}
