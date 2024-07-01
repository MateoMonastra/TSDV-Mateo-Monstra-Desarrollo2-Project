using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Player.FSM.States
{
    public abstract class State: MonoBehaviour
    {
        public List<State> transitions;
        public virtual void OnEnter() {}
        public virtual void OnUpdate() {}
        public virtual void OnFixedUpdate() {}
        public virtual void OnLateUpdate() {}
        public virtual void OnEnd() {}
        public bool CheckStateTransition(State newState)
        {
            foreach (State transition in transitions)
            {
                if (transition == newState)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
