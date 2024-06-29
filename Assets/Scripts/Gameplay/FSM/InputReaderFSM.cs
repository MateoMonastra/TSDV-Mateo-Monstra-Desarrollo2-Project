using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FSM
{
    public class InputReaderFsm : MonoBehaviour
    {
        public Action<Vector2> onMove;
        public Action onJump;

        public void HandleJumpInput(InputAction.CallbackContext context)
        {
            onJump.Invoke();
        }

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            onMove.Invoke(context.ReadValue<Vector2>());
            
        }
    }
}

