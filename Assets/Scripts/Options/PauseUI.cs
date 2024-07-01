using UnityEngine;

namespace Options
{
    public class PauseUI : MonoBehaviour
    {
        
        [Tooltip("Reference to the pause menu GameObject.")]
        [SerializeField] private GameObject pauseMenu;

        /// <summary>
        /// Initializes the pause menu by setting it active and adjusting cursor and timescale.
        /// </summary>
        public void InitPauseMenu()
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        /// <summary>
        /// Returns to the game by deactivating the pause menu and restoring cursor and timescale.
        /// </summary>
        public void Return()
        {
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }

        /// <summary>
        /// Returns to the menu and reset the timescale.
        /// </summary>
        public void GoMenu()
        {
            Time.timeScale = 1;
        }
    }
}
