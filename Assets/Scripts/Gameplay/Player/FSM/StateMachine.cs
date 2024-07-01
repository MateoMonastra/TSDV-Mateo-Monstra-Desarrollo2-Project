using Gameplay.Player.FSM.Behaviours;
using UnityEngine;

namespace Gameplay.Player.FSM
{
    public class StateMachine : MonoBehaviour
    {
        public IBehaviour CurretIBehaviour;

        private void Start()
        {
            CurretIBehaviour = GetComponent<WalkIdleIBehaviour>();
            CurretIBehaviour.Enter();
        }

        /// <summary>
        /// Changes the current state of the state machine.
        /// </summary>
        /// <param name="newIBehaviour">The new behavior to transition to.</param>
        public void ChangeState(IBehaviour newIBehaviour)
        {
            if (CurretIBehaviour == newIBehaviour || !CurretIBehaviour.CheckTransitionIsApproved(newIBehaviour)) return;

            var beforeIBehaviour = CurretIBehaviour;
            var afterIBehaviour = newIBehaviour;
            
            beforeIBehaviour.Exit();
            afterIBehaviour.Enter();

            CurretIBehaviour = afterIBehaviour;
        }

        private void Update()
        {
            CurretIBehaviour.OnBehaviourUpdate();
        }

        private void FixedUpdate()
        {
            CurretIBehaviour.OnBehaviourFixedUpdate();
        }

        private void LateUpdate()
        {
            CurretIBehaviour.OnBehaviourLateUpdate();
        }
        
    }
}