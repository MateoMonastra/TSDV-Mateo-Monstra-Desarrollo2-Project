using UnityEngine;

namespace MenuButton
{
    public abstract class ButtonHandler : ScriptableObject 
    {
        public abstract void Handle(params object[] args);
        public virtual void Set(){}
    }
}
