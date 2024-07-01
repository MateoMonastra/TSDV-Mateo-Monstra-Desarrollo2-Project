using EventSystems.EventSoundManager;
using UnityEngine;

namespace Gameplay.Coin
{
    public class Coin : MonoBehaviour
    {
        [Tooltip("Speed at which the coin rotates.")]
        [SerializeField] private float rotationSpeed;
        
        [Tooltip("Audio clip to play when the coin is collected.")]
        [SerializeField] private AudioClip clip;
        
        [Tooltip("Event channel for sound-related events.")]
        [SerializeField] private EventChannelSoundManager channel;

        public bool isActive = false;

        private void Update()
        {
            if (isActive)
            {
                transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed));
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (isActive)
            {
                channel.PlaySound(clip);
                DesactivateCoin();
            }
        }

        /// <summary>
        /// Deactivates the coin, setting isActive to false and deactivating the GameObject.
        /// </summary>
        private void DesactivateCoin()
        {
            isActive = false;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Sets the transform (position, scale, and rotation) of the coin based on provided CoinData.
        /// </summary>
        /// <param name="newPosition">CoinData containing new position, scale, and rotation.</param>
        public void SetNewTransform(CoinData newPosition)
        {
            transform.position = newPosition.Position;
            transform.localScale = newPosition.Scale;
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}