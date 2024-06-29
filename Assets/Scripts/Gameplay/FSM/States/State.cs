using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.States
{
    public abstract class State: MonoBehaviour
    {
        private Action<string> _changeStateCallBack;
        public virtual void OnStart() {}
        public virtual void OnEnd() {}
        
    }
}
