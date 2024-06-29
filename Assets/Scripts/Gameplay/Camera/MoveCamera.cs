using UnityEngine;

namespace Camera
{
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField] private Transform cameraPos;
        private void Update()
        {
            transform.position = cameraPos.position;
        }
    }
}
