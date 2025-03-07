using Gameplay.Player.FSM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu
{
    public class PreselectButton : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private InputReader inputReader;

        private GameObject _selectedButton;

        private void OnEnable()
        {
            inputReader.OnNavigate += RestartNavigation;
        }

        private void OnDisable()
        {
            inputReader.OnNavigate -= RestartNavigation;
        }

        public void SetPreselectedButton(GameObject button)
        {
            if (eventSystem != null)
            {
                eventSystem.SetSelectedGameObject(button);

                _selectedButton = button;
            }
        }

        public void RestartNavigation()
        {
            if (eventSystem != null && eventSystem.currentSelectedGameObject == null)
            {
                eventSystem.SetSelectedGameObject(_selectedButton);
            }
        }
    }
}