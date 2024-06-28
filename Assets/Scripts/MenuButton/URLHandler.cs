using System.Collections;
using System.Collections.Generic;
using MenuButton;
using UnityEngine;

[CreateAssetMenu(fileName = "URLHandler", menuName = "Models/ButtonHandler/URLHandler")]
public class URLHandler : ButtonHandler
{
    [SerializeField] private string url = "null";
    override public void Handle(params object[] args) 
    {
        if (url == "null") return;

        Application.OpenURL(url);
    }
}
