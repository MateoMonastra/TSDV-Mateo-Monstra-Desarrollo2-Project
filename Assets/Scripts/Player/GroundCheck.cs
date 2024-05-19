using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private float rayHeight;
        [SerializeField] private Transform footPivot;
        private bool _grounded;
        private float _groundedDistance;

        public bool IsOnGround()
        {
            _grounded = Physics.Raycast(footPivot.position, Vector3.down, rayHeight, whatIsGround);

            return _grounded;
        }

        private void Draw()
        {
            Gizmos.DrawRay(footPivot.position, Vector3.down * rayHeight);
        }

        void OnDrawGizmos()
        {
            Draw();
        }
    }
}