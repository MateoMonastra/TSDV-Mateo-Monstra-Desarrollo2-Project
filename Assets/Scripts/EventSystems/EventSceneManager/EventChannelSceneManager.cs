using System;
using UnityEngine;

namespace EventSystems.EventSceneManager
{
    [CreateAssetMenu(fileName = "EventChannelSceneManager", menuName = "Models/Event/Channel/EventChannelSceneManager")]
    public class EventChannelSceneManager : EventChannel
    {
        public Action<string> OnAddScene;
        public Action<string> OnRemoveScene;
        
        /// <summary>
        /// Adds a new scene through the event channel.
        /// </summary>
        /// <param name="newScene">Name of the scene to add.</param>
        public void AddScene(string newScene)
        {
            OnAddScene.Invoke(newScene);
        }
        
        /// <summary>
        /// Removes a scene through the event channel.
        /// </summary>
        /// <param name="unLoadedScene">Name of the scene to remove.</param>
        public void RemoveScene(string unLoadedScene)
        {
            OnRemoveScene.Invoke(unLoadedScene);
        }
    }
}
