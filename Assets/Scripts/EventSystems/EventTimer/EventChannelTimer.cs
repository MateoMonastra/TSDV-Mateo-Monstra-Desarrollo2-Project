using System;
using UnityEngine;

namespace EventSystems.EventTimer
{
    [CreateAssetMenu(fileName = "EventChannelTimer", menuName = "Models/Event/Channel/EventChannelTimer")]
    public class EventChannelTimer : EventListener
    {
        public Action<float> OnAddTime;
        public void AddScene(float timeToAdd)
        {
            OnAddTime.Invoke(timeToAdd);
        }
    }
}
