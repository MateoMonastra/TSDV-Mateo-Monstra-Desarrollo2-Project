using Gameplay.Player.FSM.States;
using UnityEngine;
using UnityEngine.Serialization;
using State = Gameplay.Player.FSM.States.State;

namespace Gameplay.Player.FSM.Behaviours
{
    public class JumpIBehaviour : MonoBehaviour,IBehaviour
    {
        [Tooltip("Reference to the jump state component.")]
        [SerializeField] private States.Jump jump;
        
        [Tooltip("Reference to the walk idle behavior component.")]
        [SerializeField] private WalkIdle walkIdle;
       
        [Tooltip("Reference to the state machine managing behaviors.")]
        [SerializeField] private StateMachine fsm;
        private void Start()
        {
            jump ??= GetComponent<States.Jump>();
            fsm ??= GetComponent<StateMachine>();
            walkIdle ??= GetComponent<WalkIdle>();
            jump.onJumpEnd += SetIBehaviour;
        }

        public bool CheckTransitionIsApproved(IBehaviour newBehaviour)
        {
            return jump.CheckStateTransition(newBehaviour.GetBehaviourState());
        }

        public void Enter()
        {
            jump.OnEnter();
        }

        public void OnBehaviourUpdate()
        {
            jump.OnUpdate();
        }

        public void OnBehaviourFixedUpdate()
        {
            walkIdle.OnFixedUpdate();
        }

        public void OnBehaviourLateUpdate()
        {
            jump.OnLateUpdate();
        }

        public void Exit()
        {
            jump.OnEnd();
        }

        public State GetBehaviourState()
        {
            return jump;
        }
        
        /// <summary>
        /// Sets the current behavior to walk idle after completing jump.
        /// </summary>
        private void SetIBehaviour()
        {
            fsm.CurrentIBehaviour = GetComponent<WalkIdleIBehaviour>();
        }
    }
}
