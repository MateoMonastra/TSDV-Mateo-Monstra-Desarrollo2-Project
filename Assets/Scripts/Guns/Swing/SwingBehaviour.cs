using System;
using System.Collections;
using Guns.Swing;
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

        [Header("Model")]
        [SerializeField] private SwingModel model;

        private RunningBehaviour _pm;
        
        private float _swingCdTimer;
       
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
            if (_joint)
            {
                StartCoroutine(StopSwing());
            }

            if (Physics.Raycast(playerCamera.position,playerCamera.forward,out var hit, model.GetMaxSwingDistance(), grappable))
            {
                animator.SetBool("ShootSwing",true);
                _pm.activeGun = true;
                _swingPoint = hit.point;
                _joint = transform.AddComponent<SpringJoint>();
                _joint.autoConfigureConnectedAnchor = false;
                _joint.connectedAnchor = _swingPoint;

                float distanceFromPoint = Vector3.Distance(playerCamera.position, _swingPoint);

                _joint.maxDistance = distanceFromPoint * model.GetMaxDistance();
                _joint.minDistance = distanceFromPoint * model.GetMinDistance();

                _joint.spring = model.GetSpring();
                _joint.damper = model.GetDamper();
                _joint.massScale = model.GetMassScale();

                lr.positionCount = 2;

                lr.enabled = true;

            }
            
            yield break;
        }
    
        public IEnumerator StopSwing()
        {
            animator.SetBool("ShootSwing",false);
            lr.positionCount = 0;
            if (_joint)
            {
                Destroy(_joint);
            }
            _swingCdTimer = model.GetSwingCd();
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