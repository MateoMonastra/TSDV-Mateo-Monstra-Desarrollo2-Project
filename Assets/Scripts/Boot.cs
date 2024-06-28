using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    [SerializeField] private string scene;
    private void Start()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

}
