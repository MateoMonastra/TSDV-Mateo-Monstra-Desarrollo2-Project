using EventSystems.EventSoundManager;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerSoundManager : MonoBehaviour
    {
        [Tooltip("Event channel for playing sound effects.")]
        [SerializeField] private EventChannelSoundManager channel;

        [Tooltip("Sound clip for hitting the grapple target.")]
        [SerializeField] private AudioClip grappleHitClip;

        [Tooltip("Sound clip for missing the grapple target.")]
        [SerializeField] private AudioClip grappleMissClip;
 
        [Tooltip("Audio clip played when the swing hits.")]
        [SerializeField] private AudioClip swingHitClip;
        
        [Tooltip("Audio clip played when jumping.")]
        [SerializeField] private AudioClip jumpClip;


        private void PlayGrappleHitSound()
        {
            channel.PlaySound(grappleHitClip);
        }
        
        private void PlayGrappleMissSound()
        {
            channel.PlaySound(grappleMissClip);
        }

        private void PlaySwingSound()
        {
            channel.PlaySound(swingHitClip);
        }

        private void PlayJumpSound()
        {
            channel.PlaySound(jumpClip);
        }
    }
}
