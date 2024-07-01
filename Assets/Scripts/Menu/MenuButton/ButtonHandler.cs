using UnityEngine;

namespace Menu.MenuButton
{
    public abstract class ButtonHandler : ScriptableObject 
    {
        /// <summary>
        /// Abstract method to handle the button action.
        /// </summary>
        public abstract void Handle(params object[] args);
        /// <summary>
        /// Optional virtual method to set up initial state or configurations.
        /// </summary>
        public virtual void Set(){}
    }
}
