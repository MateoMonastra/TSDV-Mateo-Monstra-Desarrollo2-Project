using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace EventSystems
{
    public class SetListener : MonoBehaviour
    {
        [SerializeField] private EventListener listener;

        private void Start()
        {
            listener.MySceneManager = FindObjectOfType<MySceneManager>();
            listener.SetEvents();
        }
    }
}