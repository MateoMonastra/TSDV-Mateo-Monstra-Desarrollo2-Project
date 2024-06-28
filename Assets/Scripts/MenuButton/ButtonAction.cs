using UnityEngine;

namespace MenuButton
{
    public class ButtonAction : MonoBehaviour
    {
        [SerializeField] private ButtonHandler buttonHandler;

        private void Start()
        {
            if (buttonHandler)
            {
                buttonHandler.Set();
            }
        }
        public void HandleClick()
        {
            if (buttonHandler)
            {
                buttonHandler.Handle();
            }
        }
        
    }
}