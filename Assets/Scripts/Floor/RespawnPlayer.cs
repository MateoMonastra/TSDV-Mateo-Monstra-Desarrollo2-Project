using System;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Floor
{
    public class RespawnPlayer : MonoBehaviour
    {
        [SerializeField] private Transform checkPoint;
        [SerializeField] private GameObject player;
        [SerializeField] private Canvas transition;
        [SerializeField] private float transitionCoolDown;

        private MeshRenderer _collider;
        private float _transitionTimer;

        private void Start()
        {
            _collider = GetComponentInChildren<MeshRenderer>();
        }

        private void Update()
        {
            _transitionTimer -= Time.deltaTime;
            
            if (_transitionTimer <= 0)
            {
                transition.enabled = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _transitionTimer = transitionCoolDown;
            transition.enabled = true;
            
            player.transform.position = checkPoint.position;

        }
    }
}