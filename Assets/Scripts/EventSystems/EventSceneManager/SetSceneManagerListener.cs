using Managers;
using UnityEngine;

namespace EventSystems.EventSceneManager
{
    public class SetSceneManagerListener : MonoBehaviour
    {
        [SerializeField] private EventListenerSceneManager listener;

        private void Start()
        {
            listener.MySceneManager = FindObjectOfType<MySceneManager>();
            listener.SetEvents();
        }
    }
}