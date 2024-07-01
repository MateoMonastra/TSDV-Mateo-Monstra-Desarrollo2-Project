using System;
using EventSystems.EventSoundManager;
using Gameplay.FSM;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Gameplay.EasterEgg
{
    public class CellPhoneEasterEgg : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        [SerializeField] private InputReaderFsm inputReaderFsm;
        [SerializeField] private LayerMask cellphoneLayer;

        [Header("Audio SFX:")] [SerializeField]
        private EventChannelSoundManager channel;

        [SerializeField] private AudioClip clip;


        private void Start()
        {
            inputReaderFsm.onGrapple += PlaySound;
        }

        void PlaySound()
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, Mathf.Infinity, cellphoneLayer))
            {
                channel.PlaySound(clip);
            }
        }
    }
}