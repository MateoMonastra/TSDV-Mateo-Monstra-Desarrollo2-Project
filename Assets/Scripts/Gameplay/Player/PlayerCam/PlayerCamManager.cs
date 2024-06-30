using System;
using Gameplay.FSM;
using UnityEngine;

namespace Gameplay.Player.PlayerCam
{
    public class PlayerCamManager : MonoBehaviour
    {
        [SerializeField] private InputReaderFsm inputReaderFsm;
        private PlayerCam _playerCam;

        private void Awake()
        {
            inputReaderFsm.onMouseCam += MoveMouseCam;
            inputReaderFsm.onJoystickCam += MoveJoystickCam;
        }

        private void Start()
        {
            _playerCam = GetComponentInChildren<PlayerCam>();
        }

        private void MoveMouseCam(Vector2 angle)
        {
            _playerCam.UpdateMouseCamera(angle);
        }
        private void MoveJoystickCam(Vector2 angle)
        {
            _playerCam.UpdateJoystickCamera(angle);
        }
    }
}
