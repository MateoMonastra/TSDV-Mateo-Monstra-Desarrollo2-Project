using UnityEngine;

namespace Gameplay.Floor
{
    public class SetCheckPoint : MonoBehaviour
    {
        [Tooltip("Reference of the respawn")]
        [SerializeField] private RespawnPlayer respawnPlayer;
        
        [Tooltip("Reference of newSpawnPoint")]
        [SerializeField] private Transform newSpawnPoint;

        private void OnCollisionEnter(Collision other)
        {
            if (newSpawnPoint == respawnPlayer.CheckPoint) return;
        
            respawnPlayer.CheckPoint = newSpawnPoint;
        }
    }
}