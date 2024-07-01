using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player.FSM
{
    public class InputReaderFsm : MonoBehaviour
    {
        public Action<Vector2> OnMove;
        public Action OnJump;
        public Action OnGrapple;
        public Action OnSwingStart;
        public Action OnSwingEnd;
        public Action<Vector2> OnMouseCam;
        public Action<Vector2> OnJoystickCam;
        public Action OnPause;
        public Action OnSpeedCheat;
        public Action OnJumperCheat;
        public Action OnPassLevelCheat;

        /// <summary>
        /// Maneja la entrada de salto.
        /// </summary>
        public void HandleJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnJump.Invoke();
            }
        }

        /// <summary>
        /// Maneja la entrada de movimiento.
        /// </summary>
        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            OnMove.Invoke(context.ReadValue<Vector2>());
        }

        /// <summary>
        /// Maneja la entrada de gancho.
        /// </summary>
        public void HandleGrappleInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnGrapple.Invoke();
            }
        }

        /// <summary>
        /// Maneja la entrada de inicio y fin de balanceo.
        /// </summary>
        public void HandleSwingInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnSwingStart.Invoke();
            }
            else if (context.canceled)
            {
                OnSwingEnd.Invoke();
            }
        }

        /// <summary>
        /// Maneja la entrada de cámara (ratón o joystick).
        /// </summary>
        public void HandleCamInput(InputAction.CallbackContext context)
        {
            if (context.control == Mouse.current)
            {
                if (context.performed)
                {
                    OnMouseCam.Invoke(context.ReadValue<Vector2>());
                }
                else
                {
                    OnMouseCam.Invoke(Vector2.zero);
                }
            }
            else
            {
                OnJoystickCam.Invoke(context.ReadValue<Vector2>());
            }
        }

        /// <summary>
        /// Maneja la entrada de pausa.
        /// </summary>
        public void HandlePauseInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnPause.Invoke();
            }
        }

        /// <summary>
        /// Maneja la entrada del truco de velocidad.
        /// </summary>
        public void HandleSpeedCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnSpeedCheat.Invoke();
            }
        }

        /// <summary>
        /// Maneja la entrada del truco de salto.
        /// </summary>
        public void HandleJumperCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnJumperCheat.Invoke();
            }
        }

        /// <summary>
        /// Maneja la entrada del truco de pasar nivel.
        /// </summary>
        public void HandlePassLevelCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnPassLevelCheat.Invoke();
            }
        }
    }
}