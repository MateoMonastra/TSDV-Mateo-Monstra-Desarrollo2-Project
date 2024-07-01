using System;
using Player.PlayerCam;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Options
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private Slider masterVol;
        [SerializeField] private Slider musicVol;
        [SerializeField] private Slider sfxVol;
        [SerializeField] private Slider sensibility;

        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private PlayerCamModel camModel;

        private void Start()
        {
            audioMixer.GetFloat("MasterVol",out var masterVolValue );

            masterVol.value = masterVolValue;
            
            audioMixer.GetFloat("MusicVol",out var musicVolValue );

            musicVol.value = musicVolValue;
            
            audioMixer.GetFloat("SfxVol",out var sfxVolValue );

            sfxVol.value = sfxVolValue;

            sensibility.value = camModel.sensX + camModel.sensY;

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
        
        public void ChangeSensibility()
        {
            camModel.sensX = sensibility.value/2;
            camModel.sensY = sensibility.value/2;
        }
    }
}
