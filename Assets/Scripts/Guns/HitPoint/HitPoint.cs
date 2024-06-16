using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Guns
{
    public class HitPoint : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        [SerializeField] private LayerMask grappable;
        [SerializeField] private float maxDistance;
        
        private Transform _point;
        private Vector3 _moveTo;


        private void OnEnable()
        {
            _point = GetComponent<Transform>();
        }

        private void Update()
        {
            
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, maxDistance,
                    grappable))
            {
                _moveTo = hit.point;
                MovePoint();
            }
            else
            {
                ResetPoint();
            }
        }

        private void MovePoint()
        {
            if (_point.position == _moveTo) return;
            
            _point.position = _moveTo;
        }

        private void ResetPoint()
        {
            if (_point.position == Vector3.zero) return;
            
            _point.position = Vector3.zero;
        }
    }
}
