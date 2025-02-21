using EventSystems.EventSoundManager;
using Gameplay.Player.FSM;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.EasterEgg
{
    public class CellPhoneEasterEgg : MonoBehaviour
    {
        [Tooltip("Reference for Raycast")]
        [SerializeField] private Transform playerCamera;
        
        [FormerlySerializedAs("inputReaderFsm")]
        [Tooltip("Reference of actual inputReader")]
        [SerializeField] private InputReader inputReader;
        
        [Tooltip("LayerMask of the EasterEgg GameObject")]
        [SerializeField] private LayerMask cellphoneLayer;

        [Header("Audio SFX:")] 
        [SerializeField] private EventChannelSoundManager channel;
        [SerializeField] private AudioClip clip;
        
        private void OnEnable()
        {
            inputReader.OnGrapple += PlaySound;
        }
        
        private void OnDisable()
        {
            inputReader.OnGrapple -= PlaySound;
        }

        /// <summary>
        /// Plays the sound effect if the player's camera raycast intersects with an object on the cellphoneLayer.
        /// </summary>
        private void PlaySound()
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, Mathf.Infinity, cellphoneLayer))
            {
                channel.PlaySound(clip);
            }
        }
    }
}