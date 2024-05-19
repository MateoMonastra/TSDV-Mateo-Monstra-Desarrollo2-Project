using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private float rayHeight = 0.2f;
        private CapsuleCollider _collider;
        private float _height;
        private bool _grounded;

        private void Start()
        {
            _collider = GetComponentInChildren<CapsuleCollider>();
            _height = _collider.height;
        }

        public bool GroundRay()
        {
            return _grounded = Physics.Raycast(transform.position, Vector3.down, _height / 2 + rayHeight, whatIsGround);
        }

        public void Draw()
        {
            Gizmos.DrawRay(transform.position,Vector3.down );
        }

        private void OnDrawGizmos()
        {
            Draw();
        }
    }
}