using UnityEngine;
using UnityEngine.SceneManagement;

namespace Options
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;

        public void InitPauseMenu() 
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        public void Return()
        {
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        public void GoMenu() 
        {
            Time.timeScale = 1;
        }
    }
}
