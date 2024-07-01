using Managers;
using UnityEngine;

namespace EventSystems.EventSceneManager
{
    [CreateAssetMenu(fileName = "EventListenerSceneManager", menuName = "Models/Event/Listener/EventListenerSceneManager")]
    public class EventListenerSceneManager : EventListener
    {
        [Tooltip("Reference to the MySceneManager component to manipulate.")]
        [SerializeField] private MySceneManager mySceneManager;
        
        [Tooltip("Event channel for scene-related events.")]
        [SerializeField] private EventChannelSceneManager eventChannel;
        
        /// <summary>
        /// Sets the MySceneManager component.
        /// </summary>
        public MySceneManager MySceneManager
        {
            set => mySceneManager = value;
        }
        
        /// <summary>
        /// Sets up event subscriptions.
        /// </summary>
        public void SetEvents()
        {
            eventChannel.OnAddScene += AddSceneListener;
            eventChannel.OnRemoveScene += RemoveScene;
        }
        
        /// <summary>
        /// Listener method for adding a scene.
        /// </summary>
        /// <param name="sceneName">Name of the scene to add.</param>
        private void AddSceneListener(string sceneName)
        {
            mySceneManager.AddScene(sceneName);
        }
        
        /// <summary>
        /// Listener method for removing a scene.
        /// </summary>
        /// <param name="sceneName">Name of the scene to remove.</param>
        private void RemoveScene(string sceneName)
        {
            mySceneManager.RemoveScene(sceneName);
        }
    }
}
