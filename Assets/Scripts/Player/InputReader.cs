using Guns.Grappler;
using Guns.Swing;
using LevelManager;
using Options;
using Player.Jump;
using Player.Running;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class InputReader : MonoBehaviour
    {
        public RunningBehaviour runBehaviour;
        public JumpBehaviour jumpBehaviour;
        public PlayerCam.PlayerCam playerCam;
        public GrapplingBehaviour grapplingBehaviour;
        public SwingBehaviour swingBehaviour;
        public PauseUI pauseUI;

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();

            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

            if (runBehaviour != null)
            {
                runBehaviour.SetDirection(moveDirection);
            }
        }

        public void HandleCamInput(InputAction.CallbackContext context)
        {
            Vector2 lookInput = context.ReadValue<Vector2>();

            if (playerCam != null)
            {
                if (context.control == Mouse.current)
                {
                    if (context.performed)
                    {
                        playerCam.UpdateMouseCamera(lookInput);
                    }
                    else
                    {
                        playerCam.UpdateMouseCamera(Vector2.zero);
                    }
                }
                else
                {
                    playerCam.UpdateJoystickCamera(lookInput);
                }
            }
        }

        public void HandleJumpInput(InputAction.CallbackContext context)
        {
            if (jumpBehaviour && context.started)
            {
                if (jumpBehaviour.OnPlay != null)
                {
                    StopCoroutine(jumpBehaviour.OnPlay);
                }

                jumpBehaviour.OnPlay = StartCoroutine(jumpBehaviour.Jump());
            }
        }

        public void HandleGrapplingInput(InputAction.CallbackContext context)
        {
            if (grapplingBehaviour && context.started)
            {
                if (grapplingBehaviour.OnPlay != null)
                {
                    StopCoroutine(grapplingBehaviour.OnPlay);
                }

                grapplingBehaviour.OnPlay = StartCoroutine(grapplingBehaviour.StartGrapple());
            }
        }

        public void HandleSwingInput(InputAction.CallbackContext context)
        {
            if (swingBehaviour && context.started)
            {
                if (swingBehaviour.OnPlay != null)
                {
                    StopCoroutine(swingBehaviour.OnPlay);
                }

                swingBehaviour.OnPlay = StartCoroutine(swingBehaviour.StartSwing());
            }
            else if (swingBehaviour && context.canceled)
            {
                swingBehaviour.StopSwing();
            }
        }

        public void HandlePauseMenuInput(InputAction.CallbackContext context)
        {
            if (pauseUI && context.started)
            {
                pauseUI.InitPauseMenu();
            }
        }
    }
}