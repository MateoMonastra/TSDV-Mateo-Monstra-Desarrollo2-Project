using EventSystems.EventSoundManager;
using Gameplay.Player.Guns.Swing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using State = Gameplay.Player.FSM.States.State;

namespace Gameplay.Player.FSM.States
{
    public class Swing : State
    {
        public UnityEvent onSwingStart;
        public UnityEvent onSwingEnd;
        public UnityEvent onSwingHit;
        
        [Header("References")]
        
        [Tooltip("Transform of the player's camera.")]
        [SerializeField] private Transform playerCamera;
        
        [Tooltip("Line renderer used for visualizing the swing.")]
        [SerializeField] private LineRenderer lr;
        
        [Tooltip("Transform representing the tip of the grappling gun.")]
        [SerializeField] private Transform gunTip;
        
        [Tooltip("Rigidbody of the player.")]
        [SerializeField] private Rigidbody rb;
        
        [Header("Model")]
        [Tooltip("Model defining swing parameters.")]
        [SerializeField] private SwingModel model;
        
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
        /// <summary>
        /// Checks that the Raycast results in true, then executes the swing
        /// </summary>
        private void StartSwing()
        {
            if (_joint) StopSwing();
            
            onSwingStart.Invoke();
            
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, model.MaxSwingDistance,
                    model.Grabbable))
            {
                onSwingHit.Invoke();
                
                _swingPoint = hit.point;

                ExecuteSwing();
            }
            else
            {
                _swingPoint = playerCamera.position + playerCamera.forward * model.MaxSwingDistance;
                Invoke(nameof(StopSwing), model.SwingDelayTime);
            }

            lr.enabled = true;
        }
        /// <summary>
        /// Creates a joint and attaches it as a component to the player to perform its effect
        /// </summary>
        private void ExecuteSwing()
        {
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
        /// <summary>
        /// deletes the joint and Stops the Swing
        /// </summary>
        private void StopSwing()
        {
            onSwingEnd.Invoke();
            
            if (_joint) Destroy(_joint);

            lr.positionCount = 0;
        }
    }
}
