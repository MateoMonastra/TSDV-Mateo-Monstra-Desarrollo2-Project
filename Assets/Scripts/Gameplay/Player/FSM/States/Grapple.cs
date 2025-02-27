using System;
using EventSystems.EventSoundManager;
using Gameplay.Player.Guns.Grappler;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Gameplay.Player.FSM.States
{
    public class Grapple : State
    {
        
        public UnityEvent onGrappleStart;
        public UnityEvent onGrappleEnd;
        public UnityEvent onGrappleMiss;
        public UnityEvent onGrappleHit;

        [Header("References")]
        [Tooltip("The player's camera transform.")]
        [SerializeField] private Transform playerCamera;

        [Tooltip("Line renderer for visualizing the grapple.")]
        [SerializeField] private LineRenderer lr;

        [Tooltip("Transform representing the gun tip.")]
        [SerializeField] private Transform gunTip;

        [Tooltip("Rigidbody of the player.")]
        [SerializeField] private Rigidbody rb;

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
            onGrappleStart.Invoke();
            
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, model.MaxGrappleDistance,
                    model.Grabbable))
            {
                _grapplePoint = hit.point;

                ExecuteGrapple();
            }
            else
            {
                _grapplePoint = playerCamera.position + playerCamera.forward * model.MaxGrappleDistance;
                onGrappleMiss.Invoke();
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
            onGrappleHit.Invoke();
            
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
           onGrappleEnd.Invoke();

            _grappling = false;
            lr.enabled = false;
            onGrappleEnd.Invoke();
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
