using Player.PlayerCam;
using UnityEngine;

namespace Gameplay.Player.PlayerCam
{
    public class PlayerCam : MonoBehaviour
    {
        [SerializeField] private PlayerCamModel model;
        
        [SerializeField] private Transform orientation;

        private float _yRotation;
        private float _xRotation;

        private Vector2 _moveDirection;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void Update()
        {
            _xRotation += _moveDirection.x;

            _yRotation -= _moveDirection.y;
            _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
            orientation.rotation = Quaternion.Euler(0, _xRotation, 0);
        }

        public void UpdateMouseCamera(Vector2 angle)
        {
            _moveDirection = new Vector2(angle.x * model.SensX, angle.y * model.SensY);
        }

        public void UpdateJoystickCamera(Vector2 axis)
        {
            _moveDirection = new Vector2(axis.x * model.SensX * Time.deltaTime, axis.y * model.SensY * Time.deltaTime);
        }
    }
}