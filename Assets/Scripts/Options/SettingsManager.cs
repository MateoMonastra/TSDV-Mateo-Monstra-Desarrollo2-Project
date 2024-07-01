using System;
using Gameplay.Player.PlayerCam;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Options
{
    public class SettingsManager : MonoBehaviour
    {
    [Tooltip("Slider for controlling the master volume.")]
    [SerializeField] private Slider masterVol;
    
    [Tooltip("Slider for controlling the music volume.")]
    [SerializeField] private Slider musicVol;
    
    [Tooltip("Slider for controlling the sound effects volume.")]
    [SerializeField] private Slider sfxVol;
    
    [Tooltip("Slider for controlling camera sensitivity.")]
    [SerializeField] private Slider sensibility;
    
    [Tooltip("Reference to the audio mixer to adjust audio settings.")]
    [SerializeField] private AudioMixer audioMixer;
    
    [Tooltip("Reference to the player camera model for adjusting sensitivity.")]
    [SerializeField] private PlayerCamModel camModel;

    private void Start()
    {
        // Retrieve and set the initial master volume value from the audio mixer.
        audioMixer.GetFloat("MasterVol", out var masterVolValue);
        masterVol.value = masterVolValue;

        // Retrieve and set the initial music volume value from the audio mixer.
        audioMixer.GetFloat("MusicVol", out var musicVolValue);
        musicVol.value = musicVolValue;

        // Retrieve and set the initial sound effects volume value from the audio mixer.
        audioMixer.GetFloat("SfxVol", out var sfxVolValue);
        sfxVol.value = sfxVolValue;

        // Set the sensitivity slider value based on the sum of sensX and sensY from the camera model.
        sensibility.value = camModel.sensX + camModel.sensY;
    }

    /// <summary>
    /// Changes the master volume based on the slider value.
    /// </summary>
    public void ChangeMasterVolume()
    {
        audioMixer.SetFloat("MasterVol", masterVol.value);
    }

    /// <summary>
    /// Changes the music volume based on the slider value.
    /// </summary>
    public void ChangeMusicVolume()
    {
        audioMixer.SetFloat("MusicVol", musicVol.value);
    }

    /// <summary>
    /// Changes the sound effects volume based on the slider value.
    /// </summary>
    public void ChangeSfxVolume()
    {
        audioMixer.SetFloat("SfxVol", sfxVol.value);
    }

    /// <summary>
    /// Changes the camera sensitivity based on the slider value.
    /// </summary>
    public void ChangeSensibility()
    {
        camModel.sensX = sensibility.value / 2;
        camModel.sensY = sensibility.value / 2;
    }
    }
}
