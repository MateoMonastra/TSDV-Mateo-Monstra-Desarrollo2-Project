using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    [Tooltip("The name of the scene to be loaded")]
    [SerializeField] private string scene;
    private void Start()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

}
