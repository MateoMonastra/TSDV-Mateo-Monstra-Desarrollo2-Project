using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class InputReader : MonoBehaviour
    {
        public RunningBehaviour runBehaviour;
        public JumpBehaviour jumpBehaviour;
        public PlayerCam playerCam;
        public GrapplingBehaviour grapplingBehaviour;
        public SwingBehaviour swingBehaviour;
        public PauseUI pauseUI;
        public PlayerCheats cheats;

        public void HandleMoveInput(InputAction.CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();

            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

            if (runBehaviour != null)
            {
                runBehaviour.Move(moveDirection);
            }
        }

        public void HandleCamInput(InputAction.CallbackContext context)
        {
            Vector2 lookInput = context.ReadValue<Vector2>();

            if (playerCam != null)
            {
                playerCam.UpdateCamera(lookInput);
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
            if (swingBehaviour != null)
            {
                if (swingBehaviour.OnPlay != null)
                {
                    StopCoroutine(swingBehaviour.OnPlay);
                }

                swingBehaviour.OnPlay = StartCoroutine(swingBehaviour.StartSwing());

                if (context.canceled)
                {
                    if (swingBehaviour.OnStop != null)
                    {
                        StopCoroutine(swingBehaviour.StopSwing());
                    }

                    swingBehaviour.OnStop = StartCoroutine(swingBehaviour.StopSwing());
                }
            }
        }

        public void HandlePauseMenuInput(InputAction.CallbackContext context)
        {
            if (pauseUI && context.started)
            {
                pauseUI.InitPauseMenu();
            }
        }

        public void HandlePassLevelInput(InputAction.CallbackContext context)
        {
            if (cheats && context.started)
            {
                cheats.PassLevel();
            }
        }
        
        public void HandleGodModeInput(InputAction.CallbackContext context)
        {
            if (cheats && context.started)
            {
                cheats.GodMode();
            }
        }
        
        public void HandleFlashModeInput(InputAction.CallbackContext context)
        {
            if (cheats && context.started)
            {
                cheats.FlashMode();
            }
        }
    }
}