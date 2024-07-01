using System;
using Gameplay.FSM.States;
using UnityEngine;

namespace Gameplay.FSM.Behaviours
{
    public class GrappleIBehaviour : MonoBehaviour, IBehaviour
    {
        private Grapple _grapple;
        
        private StateMachine _fsm;

        private void Start()
        {
            _grapple ??= GetComponent<Grapple>();
            _fsm ??= GetComponent<StateMachine>();
            
            _grapple.onEnd += SetIBehaviour;
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

        private void SetIBehaviour()
        {
            _fsm.CurretIBehaviour = GetComponent<WalkIdleIBehaviour>();
        }
    }
}
