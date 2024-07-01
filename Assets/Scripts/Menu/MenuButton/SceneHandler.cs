using EventSystems;
using EventSystems.EventSceneManager;
using UnityEngine;

namespace Menu.MenuButton
{
    [CreateAssetMenu(fileName = "SceneHandler", menuName = "Models/ButtonHandler/SceneHandler")]
    public class SceneHandler : ButtonHandler
    {
        [Tooltip("Reference to the event channel for scene management.")]
        [SerializeField] private EventChannelSceneManager eventChannel;
        
        [Tooltip("The name of the scene to add when the button is clicked.")]
        [SerializeField] private string addingScene = "null";
        
        [Tooltip("The name of the scene to unload when the button is clicked.")]
        [SerializeField] private string unLoadingScene = "null";

        /// <summary>
        /// Handles the action of adding and removing scenes based on the configured settings.
        /// </summary>
        /// <param name="args">Optional arguments for the scene handler.</param>
        public override void Handle(params object[] args)
        {
            if (unLoadingScene != "null")
            {
                eventChannel.RemoveScene(unLoadingScene);
            }
            
            if (addingScene != "null")
            {
                eventChannel.AddScene(addingScene);
            }

        }
    }
}