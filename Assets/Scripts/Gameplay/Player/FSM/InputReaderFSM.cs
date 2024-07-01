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
        public Action onSpeedCheat;
        public Action onJumperCheat;
        public Action onPassLevelCheat;

        public void HandleJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onJump.Invoke();
            }
        }

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            onMove.Invoke(context.ReadValue<Vector2>());
        }

        public void HandleGrappleInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onGrapple.Invoke();
            }
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
            if (context.started)
            {
                onPause.Invoke();
            }
        }
        
        public void HandleSpeedCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onSpeedCheat.Invoke();
            }
        }
        
        public void HandleJumperCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onJumperCheat.Invoke();
            }
        }
        
        public void HandlePassLevelCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                onPassLevelCheat.Invoke();
            }
        }
    }
}