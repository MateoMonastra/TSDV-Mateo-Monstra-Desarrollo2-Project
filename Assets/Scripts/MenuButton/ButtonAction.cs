using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuButton
{
    public class ButtonAction : MonoBehaviour
    {
        [SerializeField] private ButtonHandler buttonHandler;

        public void HandleClick()
        {
            buttonHandler.Handle();
        }
    }
}