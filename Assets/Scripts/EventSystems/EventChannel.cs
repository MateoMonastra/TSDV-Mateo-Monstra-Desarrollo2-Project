using System;
using UnityEngine;

namespace EventSystems
{
    [CreateAssetMenu(fileName = "EventChanel", menuName = "Models/Event/Channel")]
    public class EventChannel : ScriptableObject
    {
        public Action<string> OnAddScene;
        public Action<string> OnUnLoadScene;
        
        public void AddScene(string newScene)
        {
            OnAddScene.Invoke(newScene);
        }
        public void UnLoadScene(string unLoadedScene)
        {
            OnUnLoadScene.Invoke(unLoadedScene);
        }
    }
}
