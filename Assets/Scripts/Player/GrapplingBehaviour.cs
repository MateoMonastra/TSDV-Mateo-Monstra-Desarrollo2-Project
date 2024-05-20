using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class GrapplingBehaviour : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private Transform playerCamera;
        [SerializeField] private LayerMask whatIsGrappleable;
        [SerializeField] private LineRenderer lr;
        [SerializeField] private Transform gunTip;
        [SerializeField] private Rigidbody rb;
        private RunningBehaviour _pm;


        [Header("Grappling")] 
        [SerializeField] private float maxGrappleDistance;
        [SerializeField] private float grappleDelayTime;
        [SerializeField] private float overshootYAxis;

        private Vector3 _grapplePoint;

        [Header("Cooldown")] 
        [SerializeField] private float grapplingCd;
        private float _grapplingCdTimer;
        private bool _grappling;
        
        private void Start()
        {
            _pm = GetComponent<RunningBehaviour>();
        }
        private void Update()
        {
            if (_grapplingCdTimer>0)
            {
                _grapplingCdTimer -= Time.deltaTime;
            }
        }
        private void LateUpdate()
        {
            if (_grappling)
                lr.SetPosition(0,gunTip.position);
        }
        public IEnumerator StartGrapple()
        {
            if (_grapplingCdTimer > 0) yield break;

            _grappling = true;
            
            if (Physics.Raycast(playerCamera.position,playerCamera.forward,out var hit,maxGrappleDistance,whatIsGrappleable))
            {
                _grapplePoint = hit.point;
                Invoke(nameof(ExecuteGrapple),grappleDelayTime);
            }
            else
            {
                _grapplePoint = playerCamera.position + playerCamera.forward * maxGrappleDistance;
                Invoke(nameof(StopGrapple),grappleDelayTime);
            }

            lr.enabled = true;
            lr.SetPosition(1,_grapplePoint);
        }
        private void ExecuteGrapple()
        {
            _pm.freeze = false;

            Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            
            float grapplePointRelativeYPos = _grapplePoint.y - lowestPoint.y;
            float highestPointOnArc = grapplePointRelativeYPos + overshootYAxis;
            
            if (grapplePointRelativeYPos < 0) highestPointOnArc = overshootYAxis;
            
            JumpToPosition(_grapplePoint, highestPointOnArc);
            
            Invoke(nameof(StopGrapple), 1f);
            
        }
        private void StopGrapple()
        {
            _grappling = false;
            _grapplingCdTimer = grapplingCd;
            lr.enabled = false;
            _pm.activeGrapple = false;
        }
        public Vector3 CalculteJumpVelocity(Vector3 startPoint, Vector3 endPoint,float tarjectoryHeight)
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
        public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
        {
            _pm.activeGrapple = true;
            _velocityToSet = CalculteJumpVelocity(transform.position, targetPosition, trajectoryHeight);
            Invoke(nameof(SetVelocity),0.1f);
        }
        
        private Vector3 _velocityToSet;
        private void SetVelocity()
        {
            rb.velocity = _velocityToSet;
        }
    }
}