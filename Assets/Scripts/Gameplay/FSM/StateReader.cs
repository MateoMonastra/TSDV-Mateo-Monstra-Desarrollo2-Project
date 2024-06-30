using FSM.States;
using Gameplay.FSM;
using UnityEngine;
using UnityEngine.Serialization;

namespace FSM
{
    public class StateReader : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] InputReaderFsm inputReaderFsm;
        [SerializeField] StateMachine fsm;

        [FormerlySerializedAs("jump")]
        [Header("States References")]
        [SerializeField] Jump jumpController;
        [SerializeField] WalkIdle walkIdle;

        private void Awake()
        {
            inputReaderFsm.onMove += SetMoveState;
            inputReaderFsm.onJump += SetJumpState;
        }

        private void SetMoveState(Vector2 direction) 
        {
            fsm.currentState = walkIdle;
            
            walkIdle.OnStart();
            inputReaderFsm.onMove += walkIdle.SetDirection;
        }

        private void SetJumpState()
        {
            fsm.currentState = jumpController;
        }

    }
}
