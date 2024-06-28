using System;
using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;

        public bool isActive = false;

        private void Update()
        {
            if (isActive)
            {
                transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed));
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (isActive)
            {
                DesactivateCoin();
            }
        }

        private void DesactivateCoin()
        {
            isActive = false;
            gameObject.SetActive(false);
        }

        public void SetNewTransform(CoinData newPosition)
        {
            transform.position = newPosition.Position;
            transform.localScale = newPosition.Scale;
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}