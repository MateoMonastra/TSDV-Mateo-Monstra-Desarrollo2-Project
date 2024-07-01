using Gameplay.FSM.States;
using Gameplay.Player.FSM.States;
using UnityEngine;
using State = Gameplay.FSM.States.State;

namespace Gameplay.FSM.Behaviours
{
    public class JumpIBehaviour : MonoBehaviour,IBehaviour
    {
        private Jump _jump;
       
        private WalkIdle _walkIdle;

        private StateMachine _fsm;
        private void Start()
        {
            _jump ??= GetComponent<Jump>();
            _fsm ??= GetComponent<StateMachine>();
            _walkIdle ??= GetComponent<WalkIdle>();
            _jump.Jumped += SetIBehaviour;
        }

        public bool CheckTransitionIsApproved(IBehaviour newBehaviour)
        {
            return _jump.CheckStateTransition(newBehaviour.GetBehaviourState());
        }

        public void Enter()
        {
            _jump.OnEnter();
        }

        public void OnBehaviourUpdate()
        {
            _jump.OnUpdate();
        }

        public void OnBehaviourFixedUpdate()
        {
            _walkIdle.OnFixedUpdate();
        }

        public void OnBehaviourLateUpdate()
        {
            _jump.OnLateUpdate();
        }

        public void Exit()
        {
            _jump.OnEnd();
        }

        public State GetBehaviourState()
        {
            return _jump;
        }
        
        private void SetIBehaviour()
        {
            _fsm.CurretIBehaviour = GetComponent<WalkIdleIBehaviour>();
        }
    }
}
