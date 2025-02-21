using Gameplay.Player.FSM.States;
using UnityEngine;

namespace Gameplay.Player.FSM.Behaviours
{
    public class GrappleIBehaviour : MonoBehaviour, IBehaviour
    {
        private Grapple _grapple;
        
        private StateMachine _fsm;

        private void Start()
        {
            _grapple ??= GetComponent<Grapple>();
            _fsm ??= GetComponent<StateMachine>();
            
            _grapple.OnTheEnd += SetIBehaviour;
        }

        public bool CheckTransitionIsApproved(IBehaviour newBehaviour)
        {
            return _grapple.CheckStateTransition(newBehaviour.GetBehaviourState());
        }

        public void Enter()
        {
            _grapple.OnEnter();
        }

        public void OnBehaviourUpdate()
        {
            _grapple.OnUpdate();
        }

        public void OnBehaviourFixedUpdate()
        {
            _grapple.OnFixedUpdate();
        }

        public void OnBehaviourLateUpdate()
        {
            _grapple.OnLateUpdate();
        }

        public void Exit()
        {
            _grapple.OnEnd();
        }

        public State GetBehaviourState()
        {
            return _grapple;
        }

        /// <summary>
        /// Sets the current behavior to walk idle after completing jump.
        /// </summary>
        private void SetIBehaviour()
        {
            _fsm.CurrentIBehaviour = GetComponent<WalkIdleIBehaviour>();
        }
    }
}
