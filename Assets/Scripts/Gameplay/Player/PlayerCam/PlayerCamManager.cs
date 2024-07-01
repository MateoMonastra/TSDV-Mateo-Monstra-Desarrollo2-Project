using Gameplay.Player.FSM;
using UnityEngine;

namespace Gameplay.Player.PlayerCam
{
    public class PlayerCamManager : MonoBehaviour
    {
        [Header("Input Reader")] 
        [Tooltip("Reference to the InputReaderFsm scriptable object.")] 
        [SerializeField] private InputReaderFsm inputReaderFsm;

        private PlayerCam _playerCam;

        private void Awake()
        {
            inputReaderFsm.OnMouseCam += MoveMouseCam;
            inputReaderFsm.OnJoystickCam += MoveJoystickCam;
        }

        private void Start()
        {
            _playerCam = GetComponentInChildren<PlayerCam>();
        }

        /// <summary>
        /// Updates the camera angle based on mouse input.
        /// </summary>
        /// <param name="angle">The angle to move the camera.</param>
        private void MoveMouseCam(Vector2 angle)
        {
            _playerCam.UpdateMouseCamera(angle);
        }

        /// <summary>
        /// Updates the camera angle based on joystick input.
        /// </summary>
        /// <param name="angle">The angle to move the camera.</param>
        private void MoveJoystickCam(Vector2 angle)
        {
            _playerCam.UpdateJoystickCamera(angle);
        }
    }
}