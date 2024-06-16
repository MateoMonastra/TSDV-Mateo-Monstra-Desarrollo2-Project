using System.Collections;
using Player.Running;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Guns.Swing
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
        [SerializeField] private HitPoint hitPoint;

        [Header("Model")] 
        
        [SerializeField] private SwingModel model;

        private RunningBehaviour _pm;

        private float _swingCdTimer;
        private bool _grappling;

        private Vector3 _swingPoint;
        private SpringJoint _joint;

        [SerializeField] private string swingAnimationName;

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
            
            if (_joint) StopSwing();
            
            _grappling = true;
            animator.SetBool(swingAnimationName, true);

            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, model.MaxSwingDistance,
                    grappable))
            {
                _swingPoint = hit.point;
                StartCoroutine(ExecuteSwing());
            }
            else
            {
                _swingPoint = playerCamera.position + playerCamera.forward * model.MaxSwingDistance;
                // PREGUNTAR OPINION A JUMPY
                Invoke(nameof(StopSwing), model.SwingDelayTime);
            }

            lr.enabled = true;
        }
        private IEnumerator ExecuteSwing()
        {
            _pm.activeGun = true;
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
            
            yield break;
        }
        public void StopSwing()
        {
            animator.SetBool(swingAnimationName, false);
            
            if (_joint) Destroy(_joint);
            
            lr.positionCount = 0;
            _swingCdTimer = model.SwingCd;
            _pm.activeGun = false;
        }
        private void LateUpdate()
        {
            if (!_grappling || !_joint) return;
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, _swingPoint);
        }
    }
}