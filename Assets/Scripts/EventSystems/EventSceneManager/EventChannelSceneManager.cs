using System;
using UnityEngine;

namespace EventSystems
{
    [CreateAssetMenu(fileName = "EventChannelSceneManager", menuName = "Models/Event/Channel/EventChannelSceneManager")]
    public class EventChannelSceneManager : EventChannel
    {
        public Action<string> OnAddScene;
        public Action<string> OnRemoveScene;
        
        public void AddScene(string newScene)
        {
            OnAddScene.Invoke(newScene);
        }
        public void RemoveScene(string unLoadedScene)
        {
            OnRemoveScene.Invoke(unLoadedScene);
        }
    }
}
