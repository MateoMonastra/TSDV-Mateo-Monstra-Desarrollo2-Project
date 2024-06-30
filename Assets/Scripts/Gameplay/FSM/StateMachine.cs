using System;
using System.Collections.Generic;
using Gameplay.FSM.Behaviours;
using UnityEngine;
using UnityEngine.Serialization;
using State = Gameplay.FSM.States.State;

namespace Gameplay.FSM
{
    public class StateMachine : MonoBehaviour
    {
        public IBehaviour CurretIBehaviour;

        private void Start()
        {
            CurretIBehaviour = GetComponent<WalkIdleIBehaviour>();
            CurretIBehaviour.Enter();
        }

        public void ChangeState(IBehaviour newIBehaviour)
        {
            if (CurretIBehaviour == newIBehaviour || !CurretIBehaviour.CheckTransitionIsApproved(newIBehaviour)) return;

            var beforeIBehaviour = CurretIBehaviour;
            var afterIBehaviour = newIBehaviour;

            Debug.Log($"{beforeIBehaviour} cambio a {afterIBehaviour}");
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