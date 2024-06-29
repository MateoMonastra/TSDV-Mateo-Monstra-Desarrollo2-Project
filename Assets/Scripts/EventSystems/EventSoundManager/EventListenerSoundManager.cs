using Managers;
using UnityEngine;

namespace EventSystems.EventSoundManager
{
    [CreateAssetMenu(fileName = "EventListenerSoundManager", menuName = "Models/Event/Listener/SoundManager")]
    public class EventListenerSoundManager : EventListener
    {
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private EventChannelSoundManager eventChannel;
   
        public SoundManager SoundManager
        {
            set => soundManager = value;
        }
        public void SetEvents()
        {
            eventChannel.OnPlaySound += PlaySound;
            eventChannel.OnChangeSoundVolume += ChangeSoundVolume;
            
            eventChannel.OnPlayMusic += PlayMusic;
            eventChannel.OnChangeMusicVolume += ChangeMusicVolume;
        }
        private void PlaySound(AudioClip clip)
        {
            soundManager.PlaySound(clip);
        }
        private void PlayMusic(AudioClip clip)
        {
            soundManager.PlayMusic(clip);
        }
        private void ChangeSoundVolume(float volume)
        {
            soundManager.ChangeSFX_Volume(volume);
        }
        private void ChangeMusicVolume(float volume)
        {
            soundManager.ChangeMusic_Volume(volume);
        }
    }
}
