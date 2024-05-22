using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Structure
{
    public class StructureMoving : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float distance;

        private bool _finish;
        private Vector3 _endPos;

        private void Start()
        {
            _endPos = transform.position;
        }

        private void FixedUpdate()
        {
            MoveTo();
        }

        private void MoveTo()
        {
            transform.position = Vector3.Lerp(transform.position, _endPos, speed * Time.deltaTime);
        }
    }
}