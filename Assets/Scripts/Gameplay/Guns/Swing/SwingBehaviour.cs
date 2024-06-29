using System.Collections;
using EventSystems.EventSoundManager;
using Player.Running;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Guns.Swing
{
    public class SwingBehaviour : MonoBehaviour
    {
        public Coroutine OnPlay;
        public Coroutine OnStop;

        [Header("References")] 
        
        [SerializeField] private Transform playerCamera;
        [SerializeField] private LineRenderer lr;
        [SerializeField] private Transform gunTip;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator animator;
        
        [Header("Audio SFX:")] 
        
        [SerializeField] private EventChannelSoundManager channel;
        [SerializeField] private AudioClip shootClip;
        [SerializeField] private AudioClip hitClip;

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
            if (_swingCdTimer > 0 || _pm.activeGun|| _pm._groundCheck.IsOnGround()) { Debug.Log("cant shoot"); yield break; }
            
            if (_joint) StopSwing();
            

            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, model.MaxSwingDistance,
                    model.Grappeable))
            {
                channel.OnPlaySound(shootClip);
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
            if (!_joint) return;
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, _swingPoint);
        }
    }
}