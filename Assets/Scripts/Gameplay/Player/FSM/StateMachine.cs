using Gameplay.Player.FSM.Behaviours;
using UnityEngine;

namespace Gameplay.Player.FSM
{
    public class StateMachine : MonoBehaviour
    {
        public IBehaviour CurrentIBehaviour;
        private void Start()
        {
            CurrentIBehaviour = GetComponent<WalkIdleIBehaviour>();
            CurrentIBehaviour.Enter();
        }
        private void Update()
        {
            CurrentIBehaviour.OnBehaviourUpdate();
        }
        private void FixedUpdate()
        {
            CurrentIBehaviour.OnBehaviourFixedUpdate();
        }
        private void LateUpdate()
        {
            CurrentIBehaviour.OnBehaviourLateUpdate();
        }

        /// <summary>
        /// Changes the current state of the state machine.
        /// </summary>
        /// <param name="newIBehaviour">The new behavior to transition to.</param>
        public void ChangeState(IBehaviour newIBehaviour)
        {
            if (CurrentIBehaviour == newIBehaviour || !CurrentIBehaviour.CheckTransitionIsApproved(newIBehaviour)) return;

            var beforeIBehaviour = CurrentIBehaviour;
            var afterIBehaviour = newIBehaviour;
            
            beforeIBehaviour.Exit();
            afterIBehaviour.Enter();

            CurrentIBehaviour = afterIBehaviour;
        }

        
    }
}