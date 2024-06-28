using EventSystems;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace MenuButton
{
    [CreateAssetMenu(fileName = "SceneHandler", menuName = "Models/ButtonHandler/SceneHandler")]
    public class SceneHandler : ButtonHandler
    {
        [SerializeField] private EventChannel eventChannel;
        [SerializeField] private string addingScene = "null";
        [SerializeField] private string unLoadingScene = "null";

        public override void Handle(params object[] args)
        {
            if (unLoadingScene != "null")
            {
                eventChannel.UnLoadScene(unLoadingScene);
            }
            
            if (addingScene != "null")
            {
                eventChannel.AddScene(addingScene);
            }

        }
    }
}