using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateReader : MonoBehaviour
{
    [Header("References")]
    [SerializeField] InputReaderFSM inputReaderFSM;
    [SerializeField] FSM fsm;

    [Header("States References")]
    [SerializeField] Jump jump;
    [SerializeField] WalkIdle walkIdle;

    private void Awake()
    {
        inputReaderFSM.onMove += SetMoveState;
        inputReaderFSM.onJump += SetJumpState;
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
