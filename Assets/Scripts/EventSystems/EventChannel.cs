using System;
using UnityEngine;

namespace EventSystems
{
    [CreateAssetMenu(fileName = "EventChannel", menuName = "Models/Event/Channel")]
    public class EventChannel : ScriptableObject
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
