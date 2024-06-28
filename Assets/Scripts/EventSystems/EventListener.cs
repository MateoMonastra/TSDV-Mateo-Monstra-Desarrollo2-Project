using Managers;
using UnityEngine;

namespace EventSystems
{
    [CreateAssetMenu(fileName = "EventListener", menuName = "Models/Event/Listener")]
    public class EventListener : ScriptableObject
    {
        [SerializeField] private MySceneManager mySceneManager;
        [SerializeField] private EventChannel eventChannel;
        public MySceneManager MySceneManager
        {
            set => mySceneManager = value;
        }
        public void SetEvents()
        {
            eventChannel.OnAddScene += AddSceneListener;
            eventChannel.OnUnLoadScene += UnLoadScene;
        }
        private void AddSceneListener(string sceneName)
        {
            mySceneManager.AddScene(sceneName);
        }
        private void UnLoadScene(string sceneName)
        {
            mySceneManager.RemoveScene(sceneName);
        }
    }
}
