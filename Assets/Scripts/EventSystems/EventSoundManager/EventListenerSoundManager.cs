using Managers;
using UnityEngine;

namespace EventSystems.EventSoundManager
{
    [CreateAssetMenu(fileName = "EventListenerSoundManager", menuName = "Models/Event/Listener/SoundManager")]
    public class EventListenerSoundManager : EventListener
    {
        [Tooltip("Reference to the SoundManager component to manipulate.")]
        [SerializeField] private SoundManager soundManager;
        
        [Tooltip("Event channel for sound-related events.")]
        [SerializeField] private EventChannelSoundManager eventChannel;
   
        /// <summary>
        /// Sets the SoundManager component.
        /// </summary>
        public SoundManager SoundManager
        {
            set => soundManager = value;
        }
        
        /// <summary>
        /// Sets up event subscriptions.
        /// </summary>
        public void SetEvents()
        {
            eventChannel.OnPlaySound += PlaySound;
            eventChannel.OnChangeSoundVolume += ChangeSoundVolume;
            
            eventChannel.OnPlayMusic += PlayMusic;
            eventChannel.OnChangeMusicVolume += ChangeMusicVolume;
        }
        
        /// <summary>
        /// Plays a sound using the SoundManager component.
        /// </summary>
        /// <param name="clip">Audio clip to play.</param>
        private void PlaySound(AudioClip clip)
        {
            soundManager.PlaySound(clip);
        }
        
        /// <summary>
        /// Plays music using the SoundManager component.
        /// </summary>
        /// <param name="clip">Audio clip to play as music.</param>
        private void PlayMusic(AudioClip clip)
        {
            soundManager.PlayMusic(clip);
        }

        /// <summary>
        /// Changes the sound volume using the SoundManager component.
        /// </summary>
        /// <param name="volume">New volume value.</param>
        private void ChangeSoundVolume(float volume)
        {
            soundManager.ChangeSFXVolume(volume);
        }
        
        /// <summary>
        /// Changes the music volume using the SoundManager component.
        /// </summary>
        /// <param name="volume">New volume value.</param>
        private void ChangeMusicVolume(float volume)
        {
            soundManager.ChangeMusicVolume(volume);
        }
    }
}
