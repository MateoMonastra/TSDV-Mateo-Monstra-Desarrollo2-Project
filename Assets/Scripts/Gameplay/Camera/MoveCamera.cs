using UnityEngine;

namespace Gameplay.Camera
{
    public class MoveCamera : MonoBehaviour
    {
        [Tooltip("The transform whose position this object should match.")]
        [SerializeField] private Transform cameraPos;
        private void LateUpdate()
        {
            transform.position = cameraPos.position;
        }
    }
}
