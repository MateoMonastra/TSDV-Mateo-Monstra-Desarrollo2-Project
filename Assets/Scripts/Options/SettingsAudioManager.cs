using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Options
{
    public class SettingsAudioManager : MonoBehaviour
    {
        [SerializeField] private Slider masterVol;
        [SerializeField] private Slider musicVol;
        [SerializeField] private Slider sfxVol;

        [SerializeField] private AudioMixer audioMixer;

        private void Start()
        {
            audioMixer.GetFloat("MasterVol",out var masterVolValue );

            masterVol.value = masterVolValue;
            
            audioMixer.GetFloat("MusicVol",out var musicVolValue );

            musicVol.value = musicVolValue;
            
            audioMixer.GetFloat("SfxVol",out var sfxVolValue );

            sfxVol.value = sfxVolValue;
        }

        public void ChangeMasterVolume()
        {
            audioMixer.SetFloat("MasterVol", masterVol.value);
        }
    
        public void ChangeMusicVolume()
        {
            audioMixer.SetFloat("MusicVol", musicVol.value);
        }
    
        public void ChangeSfxVolume()
        {
            audioMixer.SetFloat("SfxVol", sfxVol.value);
        }
    }
}
