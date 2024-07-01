using System;
using UnityEngine;

namespace EventSystems.EventTimer
{
    [CreateAssetMenu(fileName = "EventChannelTimer", menuName = "Models/Event/Channel/EventChannelTimer")]
    public class EventChannelTimer : EventChannel
    {
        public Action<float> OnAddTime;
        
        /// <summary>
        /// Adds the specified amount of time to the timer.
        /// </summary>
        /// <param name="timeToAdd">Amount of time to add to the timer.</param>
        public void AddTime(float timeToAdd)
        {
            OnAddTime.Invoke(timeToAdd);
        }
    }
}
