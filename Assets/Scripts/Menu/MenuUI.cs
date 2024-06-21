using Credits;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Canvas menu;
        [SerializeField] private CreditsUI creditsMenu;
        [SerializeField] private int sceneLoadId;

        public void InitMenu()
        {
            menu.enabled = true;
        }
        public void Play()
        {
            SceneManager.LoadScene(sceneLoadId);
        }

        public void ShowCredits() 
        {
            menu.enabled = false;
            creditsMenu.InitCreditsMenu();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
