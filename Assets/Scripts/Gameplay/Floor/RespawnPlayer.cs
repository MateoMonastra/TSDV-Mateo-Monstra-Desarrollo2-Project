using System;
using EventSystems.EventTimer;
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
        
        [Header("Timer References")]
        [SerializeField] private EventChannelTimer eventChannelTimer;
        [SerializeField] private float timeToAdd = 20.0f;
        
        private Transform _checkPoint;
        public Transform CheckPoint
        {
            get => _checkPoint;
            set => _checkPoint = value;
        }

        private Rigidbody _playerRb;
        private float _transitionTimer;

        private void Start()
        {
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
            eventChannelTimer.OnAddTime(timeToAdd);
            
            _transitionTimer = transitionCoolDown;
            
            transition.gameObject.SetActive(true);
            
            _playerRb.velocity = new Vector3(0f, 0f, 0f);
            
            player.transform.position = _checkPoint.position;

            Debug.Log("Repawn");
        }
    }
}