using EventSystems.EventSoundManager;
using UnityEngine;

namespace Menu
{
    public class SetMusic : MonoBehaviour
    {
        [Tooltip("Reference to the event channel for the sound manager.")]
        [SerializeField] private EventChannelSoundManager channel;
        
        [Tooltip("The audio clip to be played as music.")]
        [SerializeField] private AudioClip music;
        private void Start()
        {
            channel.PlayMusic(music);
        }
    }
}
