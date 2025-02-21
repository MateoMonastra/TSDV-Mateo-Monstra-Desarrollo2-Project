using UnityEngine;

namespace Gameplay.Player
{
    public class GroundCheck : MonoBehaviour
    {
        [Tooltip("Defines what layers count as ground.")]
        [SerializeField] private LayerMask whatIsGround;
        
        [Tooltip("Height of the raycast.")]
        [SerializeField] private float rayHeight;
        
        [Tooltip("The transform representing the player's foot position.")]
        [SerializeField] private Transform footPivot;
        
        private bool _grounded;
        private float _groundedDistance;

        /// <summary>
        /// Checks if the player is currently grounded.
        /// </summary>
        public bool IsOnGround()
        {
            _grounded = Physics.Raycast(footPivot.position, Vector3.down, rayHeight, whatIsGround);

            return _grounded;
        }

        /// <summary>
        /// Draws a ray in the scene view for debugging purposes.
        /// </summary>
        private void Draw()
        {
            Gizmos.DrawRay(footPivot.position, Vector3.down * rayHeight);
        }
        
        private void OnDrawGizmos()
        {
            Draw();
        }
    }
}