using System;
using Guns.Grappler;
using Guns.Swing;
using LevelManager;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Floor
{
    public class RespawnPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject transition;
        [SerializeField] private float transitionCoolDown;
        
        private Transform _checkPoint;
        public Transform CheckPoint
        {
            get => _checkPoint;
            set => _checkPoint = value;
        }

        private Rigidbody _playerRb;
        private float _transitionTimer;
        private GrapplingBehaviour _grapplingBehaviour;
        private SwingBehaviour _swingBehaviour;

        private void Start()
        {
            _grapplingBehaviour = player.GetComponent<GrapplingBehaviour>();
            _swingBehaviour = player.GetComponent<SwingBehaviour>();
            _playerRb = player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _transitionTimer -= Time.deltaTime;

            if (!transition.gameObject.activeInHierarchy || !(_transitionTimer <= 0)) return;
            
            transition.gameObject.SetActive(false);
            _playerRb.velocity = new Vector3(0f, 0f, 0f);
        }

        private void OnTriggerEnter(Collider other)
        {
            
            _transitionTimer = transitionCoolDown;
            transition.gameObject.SetActive(true);
            _playerRb.velocity = new Vector3(0f, 0f, 0f);
            _grapplingBehaviour.StopGrapple();
            player.transform.position = _checkPoint.position;
            
            if (_swingBehaviour)
            {
                _swingBehaviour.StopSwing();
            }

            Debug.Log("Repawn");
        }
    }
}