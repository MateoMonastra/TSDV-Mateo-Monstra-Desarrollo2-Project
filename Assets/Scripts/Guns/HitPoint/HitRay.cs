using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Guns
{
    public class HitRay : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        [SerializeField] private LayerMask grappable;
        [SerializeField] private float maxDistance;
        
        private Vector3 _moveTo;

        private void Update()
        {
            
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out var hit, maxDistance,
                    grappable))
            {
                
            }
            else
            {

            }
        }
    }
}
