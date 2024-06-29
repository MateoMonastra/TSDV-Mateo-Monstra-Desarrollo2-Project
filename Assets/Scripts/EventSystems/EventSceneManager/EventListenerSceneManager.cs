using Managers;
using UnityEngine;

namespace EventSystems.EventSceneManager
{
    [CreateAssetMenu(fileName = "EventListenerSceneManager", menuName = "Models/Event/Listener/EventListenerSceneManager")]
    public class EventListenerSceneManager : EventListener
    {
        [SerializeField] private MySceneManager mySceneManager;
        [SerializeField] private EventChannelSceneManager eventChannel;
        public MySceneManager MySceneManager
        {
            set => mySceneManager = value;
        }
        public void SetEvents()
        {
            eventChannel.OnAddScene += AddSceneListener;
            eventChannel.OnRemoveScene += RemoveScene;
        }
        private void AddSceneListener(string sceneName)
        {
            mySceneManager.AddScene(sceneName);
        }
        private void RemoveScene(string sceneName)
        {
            mySceneManager.RemoveScene(sceneName);
        }
    }
}
