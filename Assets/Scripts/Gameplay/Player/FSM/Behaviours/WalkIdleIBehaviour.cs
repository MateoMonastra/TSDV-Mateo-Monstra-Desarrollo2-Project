using System;
using System.Collections.Generic;
using Gameplay.FSM.States;
using Gameplay.Player.FSM.States;
using UnityEngine;

namespace Gameplay.FSM.Behaviours
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

        public void SetDirection(Vector2 newDirection)
        {
            _walkIdle.SetDirection(newDirection);
        }
    }
}
