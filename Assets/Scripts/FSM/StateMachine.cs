using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FSM
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] List<States.States> states;

        public States.States currentState;

        private void ChangeState(States.States newState)
        {
            if (currentState == newState) return;

            var beforeState = currentState;
            var afterState= newState;
            
            beforeState.OnDisable();
            afterState.OnEnabled();

            currentState = afterState;
        }
        private void Update()
        {
            currentState.Update();
        }
        
        private void FixedUpdate()
        {
            currentState.FixedUpdate();
        }
    }
}
