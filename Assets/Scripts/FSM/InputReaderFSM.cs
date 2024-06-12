using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputReaderFSM : MonoBehaviour
{
    public Action onMove;
    public Action onJump;

    public void HandleJumpInput(InputAction.CallbackContext context)
    {
        onJump.Invoke();
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    {
        onMove.Invoke();
    }
}

