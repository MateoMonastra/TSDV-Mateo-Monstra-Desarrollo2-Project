using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        private SkinnedMeshRenderer _skinnedMeshRenderer;

        public bool isActive;
        private void Start()
        {
            _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        }

        public void OnTriggerEnter(Collider other)
        {
            _skinnedMeshRenderer.enabled = false;
            isActive = false;
            
            
        }
        
        
    }
}
