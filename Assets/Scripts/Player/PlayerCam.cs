using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerCam : MonoBehaviour
    {
        [SerializeField] private float sensX;
        [SerializeField] private float sensY;

        [SerializeField] private Transform orientation;

        private float _yRotation;
        private float _xRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
            orientation.rotation = Quaternion.Euler(0, _xRotation, 0);
        }

        public void UpdateMouseCamera(Vector2 angle)
        {
            float mouseX = angle.x * sensX;
            float mouseY = angle.y * sensY;

            _xRotation += mouseX;

            _yRotation -= mouseY;
            _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);
        }
        
        public void UpdateJoystickCamera(Vector2 axis)
        {
            float joystickX = axis.x * sensX * Time.deltaTime;
            float joystickY = axis.y * sensY * Time.deltaTime;

            _xRotation += joystickX;

            _yRotation -= joystickY;
            _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);
        }
    }
}