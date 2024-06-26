using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ExitHandler", menuName = "Models/ButtonHandler/ExitHandler")]
public class ExitHandler : ButtonHandler
{
    override public void Handle(params object[] args)
    {
        Application.Quit();
    }
}
