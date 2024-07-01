using Gameplay.FSM.Behaviours;
using Gameplay.Player.PlayerCam;
using Player;
using UnityEngine;

namespace Gameplay.FSM
{
    public class StateReader : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private InputReaderFsm inputReaderFsm;

        [SerializeField] private StateMachine fsm;

        [Header("States References")] 
        [SerializeField] private JumpIBehaviour jump;

        [SerializeField] private WalkIdleIBehaviour walkIdle;
        [SerializeField] private GrappleIBehaviour grapple;
        [SerializeField] private SwingIBehaviour swing;
        [SerializeField] private GroundCheck groundCheck;

        private void Awake()
        {
            inputReaderFsm.onMove += SetMoveStateDirection;
            inputReaderFsm.onJump += SetJumpState;
            inputReaderFsm.onGrapple += SetGrappleState;
            inputReaderFsm.onSwingStart += SetSwingState;
            inputReaderFsm.onSwingEnd += EndSwingState;
        }

        private void SetMoveStateDirection(Vector2 direction)
        {
            inputReaderFsm.onMove += walkIdle.SetDirection;
            fsm.ChangeState(walkIdle);
        }

        private void EndSwingState()
        {
            swing.Exit();
        }

        private void SetJumpState()
        {
            if (groundCheck.IsOnGround())
                fsm.ChangeState(jump);
        }

        private void SetGrappleState()
        {
            if (!groundCheck.IsOnGround())
                fsm.ChangeState(grapple);
        }

        private void SetSwingState()
        {
            if (!groundCheck.IsOnGround())
                fsm.ChangeState(swing);
        }
    }
}