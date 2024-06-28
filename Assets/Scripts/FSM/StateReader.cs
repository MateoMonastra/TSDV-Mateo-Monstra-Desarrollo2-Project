using UnityEngine;

namespace FSM
{
    public class StateReader : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] InputReaderFsm inputReaderFsm;
        [SerializeField] FsmChecker fsm;

        [Header("States References")]
        [SerializeField] Jump jump;
        [SerializeField] WalkIdle walkIdle;

        private void Awake()
        {
            inputReaderFsm.onMove += SetMoveState;
            inputReaderFsm.onJump += SetJumpState;
        }

        private void SetMoveState() 
        {
            fsm.currentState = walkIdle;
        }

        private void SetJumpState()
        {
            fsm.currentState = jump;
        }

    }
}
