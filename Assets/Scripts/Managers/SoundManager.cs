using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectSource;

        /// <summary>
        /// Function To PLay a Audio Clip That you give it by Parameter
        /// </summary>
        public void PlaySound(AudioClip clip)
        {
            effectSource.PlayOneShot(clip);
        }

        /// <summary>
        /// Play A Music That you Give it By Parameter
        /// </summary>
        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
        

        public void ChangeMusic_Volume(float volume) 
        {
            musicSource.volume = volume;
        }

        public void ChangeSFX_Volume(float volume) 
        {
            effectSource.volume = volume;
        }
    }
}
