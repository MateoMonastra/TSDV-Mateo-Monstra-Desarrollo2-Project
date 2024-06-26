using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuButton
{
    public class ButtonAction : MonoBehaviour
    {
        [SerializeField] private string url = "null";
        [SerializeField] private string scene = "null";

        public void AbrirURL()
        {
            if (url == "null") return;

            Application.OpenURL(url);
        }

        public void LoadScene()
        {
            if (scene == "null") return;

            SceneManager.LoadScene(scene);
        }

        public void CloseProject()
        {
            Application.Quit();
        }
    }
}