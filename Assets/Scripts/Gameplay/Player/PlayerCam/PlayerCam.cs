using UnityEngine;

namespace Gameplay.Player.PlayerCam
{
    public class PlayerCam : MonoBehaviour
    {
        [Header("Camera Model")]
        [Tooltip("Reference to the PlayerCamModel scriptable object.")]
        [SerializeField] private PlayerCamModel model;
    
        [Header("Orientation")]
        [Tooltip("Reference to the orientation Transform for the player.")]
        [SerializeField] private Transform orientation;

        private float _yRotation;
        private float _xRotation;

        private Vector2 _moveDirection;
        
        private void Update()
        {
            _xRotation += _moveDirection.x;

            _yRotation -= _moveDirection.y;
            _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
            orientation.rotation = Quaternion.Euler(0, _xRotation, 0);
        }

        /// <summary>
        /// Updates the camera's rotation direction based on mouse input.
        /// </summary>
        /// <param name="angle">The input angle for the camera.</param>
        public void UpdateMouseCamera(Vector2 angle)
        {
            _moveDirection = new Vector2(angle.x * model.sensX, angle.y * model.sensY);
        }

        /// <summary>
        /// Updates the camera's rotation direction based on joystick input.
        /// </summary>
        /// <param name="axis">The input axis for the camera.</param>
        public void UpdateJoystickCamera(Vector2 axis)
        {
            _moveDirection = new Vector2(axis.x * model.sensX * Time.deltaTime, axis.y * model.sensY * Time.deltaTime);
        }
    }
}