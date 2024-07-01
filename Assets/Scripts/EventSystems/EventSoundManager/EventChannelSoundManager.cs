using System;
using UnityEngine;

namespace EventSystems.EventSoundManager
{
    [CreateAssetMenu(fileName = "EventChannelSoundManager", menuName = "Models/Event/Channel/SoundManager")]
    public class EventChannelSoundManager : EventChannel
    {
        public Action<AudioClip> OnPlaySound;
        public Action<AudioClip> OnPlayMusic;
        public Action<float> OnChangeSoundVolume;
        public Action<float> OnChangeMusicVolume;
    
        
        /// <summary>
        /// Plays a sound clip through the event channel.
        /// </summary>
        /// <param name="clip">Audio clip to play.</param>
        public void PlaySound(AudioClip clip)
        {
            OnPlaySound.Invoke(clip);
        }
        
        /// <summary>
        /// Plays a music clip through the event channel.
        /// </summary>
        /// <param name="clip">Audio clip to play as music.</param>
        public void PlayMusic(AudioClip clip)
        {
            OnPlayMusic.Invoke(clip);
        }
        
        /// <summary>
        /// Changes the sound volume through the event channel.
        /// </summary>
        /// <param name="volume">New volume value.</param>
        public void ChangeSoundVolume(float volume)
        {
            OnChangeSoundVolume.Invoke(volume);
        }
        
        /// <summary>
        /// Changes the music volume through the event channel.
        /// </summary>
        /// <param name="volume">New volume value.</param>
        public void ChangeMusicVolume(float volume)
        {
            OnChangeMusicVolume.Invoke(volume);
        }
    }
}
