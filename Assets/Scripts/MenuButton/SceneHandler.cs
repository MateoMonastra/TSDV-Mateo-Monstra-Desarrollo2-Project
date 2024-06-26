using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneHandler", menuName = "Models/ButtonHandler/SceneHandler")]
public class SceneHandler : ButtonHandler
{
    [SerializeField] private string scene = "null";

    override public void Handle(params object[] args)
    {
        if (scene == "null") return;

        SceneManager.LoadScene(scene);
    }
}
