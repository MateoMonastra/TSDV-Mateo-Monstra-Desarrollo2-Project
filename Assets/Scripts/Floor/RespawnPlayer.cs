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
        [SerializeField] private Canvas transition;
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
        private bool _playerGodMode;

        private void Start()
        {
            _grapplingBehaviour = player.GetComponent<GrapplingBehaviour>();
            _swingBehaviour = player.GetComponent<SwingBehaviour>();
            _playerRb = player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _transitionTimer -= Time.deltaTime;

            if (transition.enabled && _transitionTimer <= 0)
            {
                transition.enabled = false;
                _playerRb.velocity = new Vector3(0f, 0f, 0f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _playerGodMode = other.GetComponentInParent<PlayerCheats>().godModeActivated;
            
            if (_playerGodMode) return;
            
            _transitionTimer = transitionCoolDown;
            transition.enabled = true;

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