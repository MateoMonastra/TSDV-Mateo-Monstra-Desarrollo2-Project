using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        private MeshRenderer _mr;
        private void Start()
        {
            _mr = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        }

        public void OnTriggerEnter(Collider other)
        {
            _mr.enabled = false;
        }
        
        
    }
}
