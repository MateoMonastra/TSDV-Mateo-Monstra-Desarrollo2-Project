using Gameplay.Player.FSM.States;
using UnityEngine;

namespace Gameplay.Player.FSM.Behaviours
{
    public class WalkIdleIBehaviour : MonoBehaviour, IBehaviour
    {
        private WalkIdle _walkIdle;
        
        private void Start()
        {
            _walkIdle ??= GetComponent<WalkIdle>();
        }

        public bool CheckTransitionIsApproved(IBehaviour newBehaviour)
        {
            return _walkIdle.CheckStateTransition(newBehaviour.GetBehaviourState());
        }

        public void Enter()
        {
            _walkIdle.OnEnter();
        }

        public void OnBehaviourUpdate()
        {
            _walkIdle.OnUpdate();
        }

        public void OnBehaviourFixedUpdate()
        {
            _walkIdle.OnFixedUpdate();
        }

        public void OnBehaviourLateUpdate()
        {
            _walkIdle.OnLateUpdate();
        }

        public void Exit()
        {
            _walkIdle.OnEnd();
        }

        public State GetBehaviourState()
        {
            return _walkIdle;
        }

        /// <summary>
        /// Sets the movement direction for the walk idle state.
        /// </summary>
        /// <param name="newDirection">The new direction to be set.</param>
        public void SetDirection(Vector2 newDirection)
        {
            _walkIdle.SetDirection(newDirection);
        }
    }
}
