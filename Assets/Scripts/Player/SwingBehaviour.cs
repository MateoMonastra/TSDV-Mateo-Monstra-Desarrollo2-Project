using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class SwingBehaviour : MonoBehaviour
    {
        public Coroutine OnPlay;
        public Coroutine OnStop;
        
        [Header("References")] 
        [SerializeField] private Transform playerCamera;
        [SerializeField] private LayerMask grappable;
        [SerializeField] private LineRenderer lr;
        [SerializeField] private Transform gunTip;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator animator;
        private RunningBehaviour _pm;
        
        [Header("Swinging")] 
        [SerializeField] private float maxSwingDistance = 25f;
        
        [Header("Cooldown")] 
        [SerializeField] private float swingCd;
        private float _swingCdTimer;
        
        [Header("Joint: ")]
        [SerializeField] private float maxDistance = 0.8f;
        [SerializeField] private float minDistance = 0.25f;
        [SerializeField] private float spring = 4.5f;
        [SerializeField] private float damper = 7f;
        [SerializeField] private float massScale = 4.5f;

        private Vector3 _swingPoint;
        private SpringJoint _joint;

        private void Start()
        {
            _pm = GetComponent<RunningBehaviour>();
        }
        private void Update()
        {
            if (_swingCdTimer > 0)
            {
                _swingCdTimer -= Time.deltaTime;
            }
        }
        public IEnumerator StartSwing()
        {
            
            if (_swingCdTimer > 0 || _pm.activeGun) yield break;
            if (_joint != null)
            {
                StartCoroutine(StopSwing());
            }

            if (Physics.Raycast(playerCamera.position,playerCamera.forward,out var hit,maxSwingDistance,grappable))
            {
                animator.SetBool("ShootSwing",true);
                _pm.activeGun = true;
                _swingPoint = hit.point;
                _joint = transform.AddComponent<SpringJoint>();
                _joint.autoConfigureConnectedAnchor = false;
                _joint.connectedAnchor = _swingPoint;

                float distanceFromPoint = Vector3.Distance(playerCamera.position, _swingPoint);

                _joint.maxDistance = distanceFromPoint * maxDistance;
                _joint.minDistance = distanceFromPoint * minDistance;

                _joint.spring = spring;
                _joint.damper = damper;
                _joint.massScale = massScale;

                lr.positionCount = 2;

                lr.enabled = true;

            }
            
            yield break;
        }
    
        public IEnumerator StopSwing()
        {
            animator.SetBool("ShootSwing",false);
            lr.positionCount = 0;
            Destroy(_joint);
            _swingCdTimer = swingCd;
            _pm.activeGun = false;
            yield break;
        }

        private void LateUpdate()
        {
            DrawRope();
        }

        private void DrawRope()
        {
            if (!_joint) return;
            lr.SetPosition(0,gunTip.position);
            lr.SetPosition(1,_swingPoint);
        }
    }
}
