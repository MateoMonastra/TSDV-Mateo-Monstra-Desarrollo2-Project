using Gameplay.Player.FSM.Behaviours;
using UnityEngine;

namespace Gameplay.Player.FSM
{
    public class StateReader : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("Input reader to detect player actions.")]
        [SerializeField] private InputReaderFsm inputReaderFsm;
    
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

        private void Awake()
        {
            inputReaderFsm.OnMove += SetMoveStateDirection;
            inputReaderFsm.OnJump += SetJumpState;
            inputReaderFsm.OnGrapple += SetGrappleState;
            inputReaderFsm.OnSwingStart += SetSwingState;
            inputReaderFsm.OnSwingEnd += EndSwingState;
        }

        /// <summary>
        /// Sets movement direction and changes state to walkIdle.
        /// </summary>
        /// <param name="direction">Direction of movement input.</param>
        private void SetMoveStateDirection(Vector2 direction)
        {
            inputReaderFsm.OnMove += walkIdle.SetDirection;
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