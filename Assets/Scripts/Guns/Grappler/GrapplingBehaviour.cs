using System.Collections;
using Player;
using UnityEngine;

namespace Guns.Grappler
{
    public class GrapplingBehaviour : MonoBehaviour
    {
        public Coroutine OnPlay;

        [Header("References")] 
        [SerializeField] private Transform playerCamera;

        [SerializeField] private LayerMask grappable;
        [SerializeField] private LineRenderer lr;
        [SerializeField] private Transform gunTip;
        [SerializeField] private Rigidbody rb;
        private RunningBehaviour _pm;
        [SerializeField] private Animator animator;


        [Header("Model")] 
        [SerializeField] private GrapplingModel model;

        private Vector3 _grapplePoint;

        private float _grapplingCdTimer;
        private bool _grappling;


        private void Start()
        {
            _pm = GetComponent<RunningBehaviour>();
        }

        private void Update()
        {
            if (_grapplingCdTimer > 0)
            {
                _grapplingCdTimer -= Time.deltaTime;
            }
        }

        private void LateUpdate()
        {
            if (_grappling)
                lr.SetPosition(0, gunTip.position);
        }
        
        public IEnumerator StartGrapple()
        {
            if (_grapplingCdTimer > 0 || _pm.activeGun) yield break;

            _grappling = true;
            animator.SetBool("ShootGrappler", true);


            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, model.GetMaxGrappleDistance(),
                    grappable))
            {
                _grapplePoint = hit.point;

                StartCoroutine(ExecuteGrapple());
            }
            else
            {
                _grapplePoint = playerCamera.position + playerCamera.forward * model.GetMaxGrappleDistance();
                Invoke(nameof(StopGrapple), model.grappleDelayTime);
            }

            lr.enabled = true;
            lr.SetPosition(1, _grapplePoint);
        }
        
        private IEnumerator ExecuteGrapple()
        {
            _pm.freeze = false;

            Vector3 lowestPoint =
                new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

            float grapplePointRelativeYPos = _grapplePoint.y - lowestPoint.y;
            float highestPointOnArc = grapplePointRelativeYPos + model.overshootYAxis;

            if (grapplePointRelativeYPos < 0) highestPointOnArc = model.overshootYAxis;

            if (_grappling)
            {
                JumpToPosition(_grapplePoint, highestPointOnArc);
            }

            Invoke(nameof(StopGrapple), 1f);
            
            yield break;
        }

        public void StopGrapple()
        {
            animator.SetBool("ShootGrappler", false);
            StopCoroutine(ExecuteGrapple());

            _grappling = false;
            _grapplingCdTimer = model.grapplingCd;
            lr.enabled = false;
            _pm.activeGun = false;
        }

        private Vector3 CalculteJumpVelocity(Vector3 startPoint, Vector3 endPoint, float tarjectoryHeight)
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

        private Vector3 _velocityToSet;

        public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
        {
            _pm.activeGun = true;
            _velocityToSet = CalculteJumpVelocity(transform.position, targetPosition, trajectoryHeight);
            Invoke(nameof(SetVelocity), 0.1f);
        }

        private void SetVelocity()
        {
            rb.velocity = _velocityToSet;
        }

        public void ResetVelocity()
        {
            rb.velocity = Vector3.zero;
        }
    }
}