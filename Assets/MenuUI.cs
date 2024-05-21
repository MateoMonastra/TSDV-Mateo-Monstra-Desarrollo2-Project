using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Canvas menu;
    [SerializeField] private CreditsUI creditsMenu;

    public void InitMenu()
    {
        menu.enabled = true;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
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
