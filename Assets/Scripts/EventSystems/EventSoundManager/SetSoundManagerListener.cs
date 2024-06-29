using EventSystems.EventSceneManager;
using Managers;
using UnityEngine;

namespace EventSystems.EventSoundManager
{
    public class SetSoundManagerListener : MonoBehaviour
    {
        [SerializeField] private EventListenerSoundManager listener;
        private void Start()
        {
            listener.SoundManager = GetComponent<SoundManager>();
            listener.SetEvents();
        }
    }
}
