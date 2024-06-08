using UnityEngine;
using UnityEngine.SceneManagement;

namespace Options
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] private Canvas pauseMenu;

        public void InitPauseMenu() 
        {
            pauseMenu.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        public void Return()
        {
            pauseMenu.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        public void GoMenu() 
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
