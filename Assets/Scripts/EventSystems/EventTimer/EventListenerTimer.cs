using LevelManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace EventSystems.EventTimer
{
    [CreateAssetMenu(fileName = "EventListenerTimer", menuName = "Models/Event/Listener/EventListenerTimer")]
    public class EventListenerTimer : EventListener
    {
        [SerializeField] private Timer timer;
        [SerializeField] private EventChannelTimer eventChannel;

        public Timer Timer
        {
            set => timer = value;
        }
        
        public void SetEvents()
        {
            eventChannel.OnAddTime += AddTime;
        }

        private void AddTime(float timeToAdd)
        {
            timer.AddTime(timeToAdd);
        }
        
    }
}
