using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputReaderFSM : MonoBehaviour
{
    FSM fsm;

    [SerializeField] Jump jump;
    [SerializeField] WalkIdle walkIdle;

    public void HandleJumpInput(InputAction.CallbackContext context)
    {
        fsm.currentState = jump;
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    {
        fsm.currentState = walkIdle;
    }
}

