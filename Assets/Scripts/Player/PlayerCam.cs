using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerCam : MonoBehaviour
    {
        [SerializeField] private float sensX;
        [SerializeField] private float sensY;

        [SerializeField] private Transform orientation;

        private float _xRotation;
        private float _yRotation;

        private bool firstFrame = true; 

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void UpdateCamera(Vector2 angle)
        {
            if (firstFrame)
            {
                firstFrame = false;
                return;
            }

            float mouseX = angle.x * Time.deltaTime * sensX;
            float mouseY = angle.y * Time.deltaTime * sensY;

            _yRotation += mouseX;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}