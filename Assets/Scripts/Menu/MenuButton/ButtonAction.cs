using UnityEngine;

namespace Menu.MenuButton
{
    public class ButtonAction : MonoBehaviour
    {
        [Tooltip("Reference to the button handler")]
        [SerializeField] private ButtonHandler buttonHandler;

        private void Start()
        {
            if (buttonHandler)
            {
                buttonHandler.Set();
            }
        }
        
        /// <summary>
        /// Handles the click event by calling the Handle method of the button handler.
        /// </summary>
        public void HandleClick()
        {
            if (buttonHandler)
            {
                buttonHandler.Handle();
            }
        }
        
    }
}