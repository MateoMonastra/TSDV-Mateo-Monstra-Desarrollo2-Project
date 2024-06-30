using Gameplay.FSM.States;
using UnityEngine;

namespace Gameplay.FSM.Behaviours
{
    public class SwingIBehaviour : MonoBehaviour, IBehaviour
    {
        private Swing _swing;

        private StateMachine _fsm;
        private void Start()
        {
            _swing ??= GetComponent<Swing>();
            _fsm ??= GetComponent<StateMachine>();
        }

        public bool CheckTransitionIsApproved(IBehaviour newBehaviour)
        {
            return _swing.CheckStateTransition(newBehaviour.GetBehaviourState());
        }

        public void Enter()
        {
            _swing.OnEnter();
        }

        public void OnBehaviourUpdate()
        {
            _swing.OnUpdate();
        }

        public void OnBehaviourFixedUpdate()
        {
            _swing.OnFixedUpdate();
        }

        public void OnBehaviourLateUpdate()
        {
            _swing.OnLateUpdate();
        }

        public void Exit()
        {
            _swing.OnEnd();
            SetIBehaviour();
        }

        public State GetBehaviourState()
        {
            return _swing;
        }
        
        private void SetIBehaviour()
        {
            _fsm.CurretIBehaviour = GetComponent<WalkIdleIBehaviour>();
        }
    }
}
