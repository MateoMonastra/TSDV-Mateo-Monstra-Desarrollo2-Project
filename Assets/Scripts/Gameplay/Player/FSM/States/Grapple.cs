using System;
using System.Collections;
using EventSystems.EventSoundManager;
using Guns.Grappler;
using Player;
using Player.Running;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.FSM.States
{
    public class Grapple : State
    {
        public Action onEnd;
        [Header("References")] 
        [SerializeField] private Transform playerCamera;
        [SerializeField] private LineRenderer lr;
        [SerializeField] private Transform gunTip;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator animator;
        [SerializeField] private string grapplerAnimationName;

        [Header("Audio SFX:")] 
        [SerializeField] private EventChannelSoundManager channel;
        [SerializeField] private AudioClip shootClip;
        [SerializeField] private AudioClip hitClip;
        [SerializeField] private AudioClip missClip;

        [Header("Model")] 
        [SerializeField] private GrapplingModel model;

        private Vector3 _grapplePoint;
        
        private bool _grappling;
        
        private Vector3 _velocityToSet;

        public override void OnEnter()
        {
            StartGrapple();
        }
        public override void OnUpdate()
        {
        }
        public override void OnLateUpdate()
        {
            if (_grappling)
                lr.SetPosition(0, gunTip.position);
        }
        private void StartGrapple()
        {
            _grappling = true;
            animator.SetBool(grapplerAnimationName, true);
            

            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, model.MaxGrappleDistance,
                    model.Grappeable))
            {
                _grapplePoint = hit.point;

                ExecuteGrapple();
            }
            else
            {
                _grapplePoint = playerCamera.position + playerCamera.forward * model.MaxGrappleDistance;
                channel.PlaySound(missClip);
                Invoke(nameof(StopGrapple), model.GrappleDelayTime);
            }

            lr.enabled = true;
            lr.SetPosition(1, _grapplePoint);
        }
        private void ExecuteGrapple()
        {
            channel.PlaySound(hitClip);
            
            rb.velocity = Vector3.zero;

            Vector3 lowestPoint =
                new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

            float grapplePointRelativeYPos = _grapplePoint.y - lowestPoint.y;
            float highestPointOnArc = grapplePointRelativeYPos + model.OvershootYAxis;

            if (grapplePointRelativeYPos < 0) highestPointOnArc = model.OvershootYAxis;

            if (_grappling)
            {
                JumpToPosition(_grapplePoint, highestPointOnArc);
            }

            Invoke(nameof(StopGrapple), model.GrappleDuration);
        }
        private void StopGrapple()
        {
            animator.SetBool(grapplerAnimationName, false);

            _grappling = false;
            lr.enabled = false;
            onEnd.Invoke();
        }
        private Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float tarjectoryHeight)
        {
            //formula sacada de este video : https://www.youtube.com/watch?v=IvT8hjy6q4o

            float gravity = Physics.gravity.y;
            float displacementY = endPoint.y - startPoint.y;

            Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0, endPoint.z - startPoint.z);

            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * tarjectoryHeight);
            Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * tarjectoryHeight / gravity) +
                                                   Mathf.Sqrt(2 * (displacementY - tarjectoryHeight) / gravity));

            return velocityXZ + velocityY;
        }
        private void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
        {
            _velocityToSet = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
            Invoke(nameof(SetVelocity), 0.1f);
        }
        private void SetVelocity()
        {
            rb.velocity = _velocityToSet;
        }
    }
}
