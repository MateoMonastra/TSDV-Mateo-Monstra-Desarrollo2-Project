using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.FSM
{
    public class InputReaderFsm : MonoBehaviour
    {
        public Action<Vector2> onMove;
        public Action onJump;
        public Action onGrapple;
        public Action onSwingStart;
        public Action onSwingEnd;
        public Action<Vector2> onMouseCam;
        public Action<Vector2> onJoystickCam;
        public Action onPause;

        public void HandleJumpInput(InputAction.CallbackContext context)
        {
            onJump.Invoke();
        }

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            onMove.Invoke(context.ReadValue<Vector2>());
        }

        public void HandleGrappleInput(InputAction.CallbackContext context)
        {
            onGrapple.Invoke();
        }

        public void HandleSwingInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onSwingStart.Invoke();
            }
            else if (context.canceled)
            {
                onSwingEnd.Invoke();
            }
        }

        public void HandleCamInput(InputAction.CallbackContext context)
        {
            if (context.control == Mouse.current)
            {
                if (context.performed)
                {
                    onMouseCam.Invoke(context.ReadValue<Vector2>());
                }
                else
                {
                    onMouseCam.Invoke(Vector2.zero);
                }
            }
            else
            {
                onJoystickCam.Invoke(context.ReadValue<Vector2>());
            }
        }
        
        public void HandlePauseInput(InputAction.CallbackContext context)
        {
            onPause.Invoke();
        }
    }
}