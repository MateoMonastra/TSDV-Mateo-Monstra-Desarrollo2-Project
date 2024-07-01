using Managers;
using UnityEngine;

namespace EventSystems.EventSoundManager
{
    public class SetSoundManagerListener : MonoBehaviour
    {
        [Tooltip("Reference to the event listener for the sound manager.")]
        [SerializeField] private EventListenerSoundManager listener;
        private void OnEnable()
        {
            listener.SoundManager = GetComponent<SoundManager>();
            listener.SetEvents();
        }
    }
}
