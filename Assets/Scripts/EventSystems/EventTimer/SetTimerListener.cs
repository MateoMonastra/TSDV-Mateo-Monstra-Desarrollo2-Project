using Gameplay.Timer;
using UnityEngine;

namespace EventSystems.EventTimer
{
    public class SetTimerListener : MonoBehaviour
    {
        [Tooltip("Reference to the EventListenerTimer component.")]
        [SerializeField] private EventListenerTimer listener;

        private void Start()
        {
            listener.Timer = FindObjectOfType<Timer>();
            listener.SetEvents();
        }
    }
}
