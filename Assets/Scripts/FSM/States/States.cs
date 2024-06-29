using System.Collections.Generic;
using UnityEngine;

namespace FSM.States
{
    [System.Serializable]
    public abstract class States
    {
        private List<States> _possibleTransition;
        public States(List<States> possibleTransitions)
        {
            _possibleTransition = possibleTransitions;
        }
        public virtual void OnEnabled() {}
        public virtual void Update() {}
        public virtual void FixedUpdate() {}
        public virtual void OnDisable() {}
        
    }
}
