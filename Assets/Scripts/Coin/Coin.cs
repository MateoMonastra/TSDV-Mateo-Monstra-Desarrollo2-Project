using System;
using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        private MeshRenderer meshRenderer;

        public bool isActive = true;
        private void Start()
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed));

        }

        public void OnTriggerEnter(Collider other)
        {
            isActive = false;
            if (meshRenderer.enabled)
            {
                DesactivateCoin();
            }
        }

        public void ActivateCoin() 
        {
            meshRenderer.enabled = true;
        }

        public void DesactivateCoin()
        {
            meshRenderer.enabled = false;
        }

    }
}
