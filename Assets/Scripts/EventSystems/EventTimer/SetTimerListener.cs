using LevelManager;
using UnityEngine;

namespace EventSystems.EventTimer
{
    public class SetTimerListener : MonoBehaviour
    {
        [SerializeField] private EventListenerTimer listener;

        private void Start()
        {
            listener.Timer = FindObjectOfType<Timer>();
            listener.SetEvents();
        }
    }
}
