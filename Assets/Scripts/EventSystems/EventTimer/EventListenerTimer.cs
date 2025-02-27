using Gameplay.Timer;
using UnityEngine;

namespace EventSystems.EventTimer
{
    [CreateAssetMenu(fileName = "EventListenerTimer", menuName = "Models/Event/Listener/EventListenerTimer")]
    public class EventListenerTimer : EventListener
    {
        [Tooltip("Reference to the Timer component to manipulate.")]
        [SerializeField] private Timer timer;
        
        [Tooltip("Event channel for timer-related events.")]
        [SerializeField] private EventChannelTimer eventChannel;

        /// <summary>
        /// Sets the Timer component.
        /// </summary>
        public Timer Timer
        {
            set => timer = value;
        }
        
        /// <summary>
        /// Sets up event subscriptions.
        /// </summary>
        public void SetEvents()
        {
            eventChannel.OnAddTime += AddTime;
        }

        public void ClearEvents()
        {
            eventChannel.OnAddTime -= AddTime;
        }

        /// <summary>
        /// Adds the specified amount of time to the Timer component.
        /// </summary>
        /// <param name="timeToAdd">Amount of time to add.</param>
        private void AddTime(float timeToAdd)
        {
            timer.AddTime(timeToAdd);
        }
        
    }
}
