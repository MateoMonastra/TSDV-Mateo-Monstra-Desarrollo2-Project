using Gameplay.Player.FSM;
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Player.PlayerCam
{
    public class PlayerCamManager : MonoBehaviour
    {
        public Action OnCameraRotation;

        [Tooltip("Reference to the InputReaderFsm scriptable object.")] 
        [SerializeField] private InputReader inputReader;
        
        private PlayerCam _playerCam;

        private void Start()
        {
            _playerCam = GetComponentInChildren<PlayerCam>();
        }
        private void OnEnable()
        {
            inputReader.OnMouseCam += MoveMouseCam;
            inputReader.OnJoystickCam += MoveJoystickCam;
        }
        private void OnDisable()
        {
            inputReader.OnMouseCam -= MoveMouseCam;
            inputReader.OnJoystickCam -= MoveJoystickCam;
        }
        
        /// <summary>
        /// Updates the camera angle based on mouse input.
        /// </summary>
        /// <param name="angle">The angle to move the camera.</param>
        private void MoveMouseCam(Vector2 angle)
        {
            _playerCam.UpdateMouseCamera(angle);
            OnCameraRotation.Invoke();
        }
        
        /// <summary>
        /// Updates the camera angle based on joystick input.
        /// </summary>
        /// <param name="angle">The angle to move the camera.</param>
        private void MoveJoystickCam(Vector2 angle)
        {
            _playerCam.UpdateJoystickCamera(angle);
            OnCameraRotation.Invoke();
        }
    }
}