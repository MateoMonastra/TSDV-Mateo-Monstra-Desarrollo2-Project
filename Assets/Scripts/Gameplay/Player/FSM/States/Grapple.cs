using System;
using EventSystems.EventSoundManager;
using Gameplay.Player.Guns.Grappler;
using UnityEngine;

namespace Gameplay.Player.FSM.States
{
    public class Grapple : State
    {
        public Action OnTheEnd;

        [Header("References")]
        [Tooltip("The player's camera transform.")]
        [SerializeField] private Transform playerCamera;

        [Tooltip("Line renderer for visualizing the grapple.")]
        [SerializeField] private LineRenderer lr;

        [Tooltip("Transform representing the gun tip.")]
        [SerializeField] private Transform gunTip;

        [Tooltip("Rigidbody of the player.")]
        [SerializeField] private Rigidbody rb;

        [Tooltip("Animator for the grappling animation.")]
        [SerializeField] private Animator animator;

        [Tooltip("Name of the grappling animation parameter.")]
        [SerializeField] private string grapplerAnimationName;

        [Header("Audio SFX:")]
        [Tooltip("Event channel for playing sound effects.")]
        [SerializeField] private EventChannelSoundManager channel;

        [Tooltip("Sound clip for hitting the grapple target.")]
        [SerializeField] private AudioClip hitClip;

        [Tooltip("Sound clip for missing the grapple target.")]
        [SerializeField] private AudioClip missClip;

        [Header("Model")]
        [Tooltip("Model containing grapple parameters.")]
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
        /// <summary>
        /// Checks that the Raycast results in true, then executes the grapple; if it returns false, it simply plays a "failure animation" with its corresponding sound
        /// </summary>
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
        /// <summary>
        /// Using the variables, calculates the jump and executes it, then calls the stop
        /// </summary>
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
        /// <summary>
        /// Stops the grapple and makes the animation
        /// </summary>
        private void StopGrapple()
        {
            animator.SetBool(grapplerAnimationName, false);

            _grappling = false;
            lr.enabled = false;
            OnTheEnd.Invoke();
        }
        
        /// <summary>
        /// Calculation of the parabola between the startPoint and the endPoint.
        /// </summary>
        private Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float tarjectoryHeight)
        {
            //If you want to know more, here is the video: https://www.youtube.com/watch?v=IvT8hjy6q4o

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
        
        /// <summary>
        /// Set rigidbody velocity to the calculated jump velocity
        /// </summary>
        private void SetVelocity()
        {
            rb.velocity = _velocityToSet;
        }
    }
}
