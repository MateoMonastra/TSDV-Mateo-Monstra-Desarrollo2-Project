using FSM.States;
using UnityEngine;

namespace FSM
{
    public class StateReader : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] InputReaderFsm inputReaderFsm;
        [SerializeField] StateMachine fsm;

        [Header("States References")]
        [SerializeField] Jump jump;
        [SerializeField] WalkIdle walkIdle;

        private void Awake()
        {
            inputReaderFsm.onMove += SetMoveState;
            inputReaderFsm.onJump += SetJumpState;
        }

        private void SetMoveState(Vector2 direction) 
        {
            fsm.currentState = walkIdle;
            
            walkIdle.OnEnabled();
            inputReaderFsm.onMove += walkIdle.SetDirection;
        }

        private void SetJumpState()
        {
            fsm.currentState = jump;
        }

    }
}
