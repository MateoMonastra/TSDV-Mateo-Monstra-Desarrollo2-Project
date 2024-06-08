using Menu;
using UnityEngine;

namespace Credits
{
    public class CreditsUI : MonoBehaviour
    {
        [SerializeField] private Canvas creditsMenu;
        [SerializeField] private MenuUI menu;

        public void InitCreditsMenu()
        {
            creditsMenu.enabled = true;
        }
        public void Return()
        {
            creditsMenu.enabled = false;
            menu.InitMenu();
        }
    }
}
