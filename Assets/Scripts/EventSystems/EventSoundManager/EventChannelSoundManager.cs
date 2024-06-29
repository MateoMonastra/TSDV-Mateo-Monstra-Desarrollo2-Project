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
    
        public void PlaySound(AudioClip clip)
        {
            OnPlaySound.Invoke(clip);
        }
        
        public void PlayMusic(AudioClip clip)
        {
            OnPlayMusic.Invoke(clip);
        }
        
        public void ChangeSoundVolume(float volume)
        {
            OnChangeSoundVolume.Invoke(volume);
        }
        
        public void ChangeMusicVolume(float volume)
        {
            OnChangeMusicVolume.Invoke(volume);
        }
    }
}
