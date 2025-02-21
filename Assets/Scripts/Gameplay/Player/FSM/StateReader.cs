using Gameplay.Player.FSM.Behaviours;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Player.FSM
{
    public class StateReader : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Input reader to detect player actions.")]
        [SerializeField] private InputReader inputReader;
    
        [Tooltip("State machine responsible for managing player states.")]
        [SerializeField] private StateMachine fsm;

        [Header("States References")]
        [Tooltip("State for jumping behavior.")]
        [SerializeField] private JumpIBehaviour jump;
    
        [Tooltip("State for idle and walking behavior.")]
        [SerializeField] private WalkIdleIBehaviour walkIdle;
    
        [Tooltip("State for grappling behavior.")]
        [SerializeField] private GrappleIBehaviour grapple;
    
        [Tooltip("State for swinging behavior.")]
        [SerializeField] private SwingIBehaviour swing;
    
        [Tooltip("Component to check if the player is on the ground.")]
        [SerializeField] private GroundCheck groundCheck;

        private void OnEnable()
        {
            inputReader.OnMove += SetMoveStateDirection;
            inputReader.OnJump += SetJumpState;
            inputReader.OnGrapple += SetGrappleState;
            inputReader.OnSwingStart += SetSwingState;
            inputReader.OnSwingEnd += EndSwingState;
        }
        private void OnDisable()
        {
            inputReader.OnMove -= SetMoveStateDirection;
            inputReader.OnJump -= SetJumpState;
            inputReader.OnGrapple -= SetGrappleState;
            inputReader.OnSwingStart -= SetSwingState;
            inputReader.OnSwingEnd -= EndSwingState;
        }
        /// <summary>
        /// Sets movement direction and changes state to walkIdle.
        /// </summary>
        /// <param name="direction">Direction of movement input.</param>
        private void SetMoveStateDirection(Vector2 direction)
        {
            inputReader.OnMove += walkIdle.SetDirection;
            fsm.ChangeState(walkIdle);
        }
        /// <summary>
        /// Ends the swing state.
        /// </summary>
        private void EndSwingState()
        {
            swing.Exit();
        }
        /// <summary>
        /// Sets the jump state if the player is on the ground.
        /// </summary>
        private void SetJumpState()
        {
            if (groundCheck.IsOnGround())
                fsm.ChangeState(jump);
        }
        /// <summary>
        /// Sets the grapple state if the player is not on the ground.
        /// </summary>
        private void SetGrappleState()
        {
            if (!groundCheck.IsOnGround())
                fsm.ChangeState(grapple);
        }
        /// <summary>
        /// Sets the swing state if the player is not on the ground.
        /// </summary>
        private void SetSwingState()
        {
            if (!groundCheck.IsOnGround())
                fsm.ChangeState(swing);
        }
    }
}