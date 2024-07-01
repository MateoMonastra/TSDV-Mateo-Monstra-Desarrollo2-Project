using UnityEngine;

namespace Gameplay.Player.Jump
{
    [CreateAssetMenu(fileName = "JumpModel", menuName = "Models/Player/Jump")]
    public class JumpModel : ScriptableObject
    {
        [Header("Jump Properties")]
        [Tooltip("The force applied when the character jumps.")]
        public float jumpForce;

        [Tooltip("The cooldown time between jumps.")]
        [SerializeField] private float jumpCooldown;

        public float JumpCooldown => jumpCooldown;
    }
    
}
