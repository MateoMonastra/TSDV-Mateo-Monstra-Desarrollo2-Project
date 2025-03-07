using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Gameplay.Player.FSM
{
    public class InputReader : MonoBehaviour
    {
        public Action<Vector2> OnMove;
        public Action OnNavigate;
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

        public bool activateLogs;

        public void HandleNavigate(InputAction.CallbackContext context)
        {
            OnNavigate?.Invoke();

            if (activateLogs)
                Debug.Log("OnNavigate was called");
        }

        /// <summary>
        /// Maneja la entrada de salto.
        /// </summary>
        public void HandleJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnJump?.Invoke();

                if (activateLogs)
                    Debug.Log("OnJump was called");
            }
        }

        /// <summary>
        /// Maneja la entrada de movimiento.
        /// </summary>
        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context.ReadValue<Vector2>());

            if (activateLogs)
                Debug.Log("OnMove was called");
        }

        /// <summary>
        /// Maneja la entrada de gancho.
        /// </summary>
        public void HandleGrappleInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnGrapple?.Invoke();
                if (activateLogs)
                    Debug.Log("OnGrapple was called");
            }
        }

        /// <summary>
        /// Maneja la entrada de inicio y fin de balanceo.
        /// </summary>
        public void HandleSwingInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnSwingStart?.Invoke();
                if (activateLogs)
                    Debug.Log("OnSwingStart was called");
            }
            else if (context.canceled)
            {
                OnSwingEnd?.Invoke();
                if (activateLogs)
                    Debug.Log("OnSwingEnd was called");
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
                    OnMouseCam?.Invoke(context.ReadValue<Vector2>());
                    if (activateLogs)
                        Debug.Log("OnMouseCam was called");
                }
                else
                {
                    OnMouseCam?.Invoke(Vector2.zero);
                    if (activateLogs)
                        Debug.Log("OnMouseCam was called");
                }
            }
            else
            {
                OnJoystickCam?.Invoke(context.ReadValue<Vector2>());
                if (activateLogs)
                    Debug.Log("OnJoystickCam was called");
            }
        }

        /// <summary>
        /// Maneja la entrada de pausa.
        /// </summary>
        public void HandlePauseInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnPause?.Invoke();
                if (activateLogs)
                    Debug.Log("OnPause was called");
            }
        }

        /// <summary>
        /// Maneja la entrada del truco de velocidad.
        /// </summary>
        public void HandleSpeedCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnSpeedCheat?.Invoke();
                if (activateLogs)
                    Debug.Log("OnSpeedCheat was called");
            }
        }

        /// <summary>
        /// Maneja la entrada del truco de salto.
        /// </summary>
        public void HandleJumperCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnJumperCheat?.Invoke();
                if (activateLogs)
                    Debug.Log("OnJumperCheat was called");
            }
        }

        /// <summary>
        /// Maneja la entrada del truco de pasar nivel.
        /// </summary>
        public void HandlePassLevelCheatInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnPassLevelCheat?.Invoke();
                if (activateLogs)
                    Debug.Log("OnPassLevelCheat was called");
            }
        }
    }
}