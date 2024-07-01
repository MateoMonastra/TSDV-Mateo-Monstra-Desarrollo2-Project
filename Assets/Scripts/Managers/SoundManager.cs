using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        [Tooltip("The AudioSource component used for playing music.")]
        [SerializeField] private AudioSource musicSource;
        
        [Tooltip("The AudioSource component used for playing sound effects.")]
        [SerializeField] private AudioSource effectSource;

        /// <summary>
        /// Plays a sound effect from the given audio clip.
        /// </summary>
        /// <param name="clip">The audio clip to play.</param>
        public void PlaySound(AudioClip clip)
        {
            effectSource.PlayOneShot(clip);
        }

        /// <summary>
        /// Plays a music track from the given audio clip.
        /// </summary>
        /// <param name="clip">The audio clip to play.</param>
        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        /// <summary>
        /// Changes the volume of the music.
        /// </summary>
        /// <param name="volume">The new volume level.</param>
        public void ChangeMusicVolume(float volume)
        {
            musicSource.volume = volume;
        }

        /// <summary>
        /// Changes the volume of the sound effects.
        /// </summary>
        /// <param name="volume">The new volume level.</param>
        public void ChangeSFXVolume(float volume)
        {
            effectSource.volume = volume;
        }
    }
}
