using UnityEngine;

namespace Player.Jump
{
    [CreateAssetMenu(fileName = "JumpModel", menuName = "Models/Player/Jump")]
    public class JumpModel : ScriptableObject
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpCooldown;
        [SerializeField] private float coyoteTime;

        public float JumpForce => jumpForce;
        public float JumpCooldown => jumpCooldown;
        public float CoyoteTime => coyoteTime;
    }
    
}
