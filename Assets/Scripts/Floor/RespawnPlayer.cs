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
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private Canvas transition;
        [SerializeField] private float transitionCoolDown;

        private MeshRenderer _collider;
        private float _transitionTimer;
        private GrapplingBehaviour _grapplingBeha;
        private SwingBehaviour _swingBeha;
        private bool _playerGodMode;

        private void Start()
        {
            _collider = GetComponentInChildren<MeshRenderer>();
            _grapplingBeha = player.GetComponent<GrapplingBehaviour>();
            _swingBeha = player.GetComponent<SwingBehaviour>();
        }

        private void Update()
        {
            _transitionTimer -= Time.deltaTime;

            if (transition.enabled && _transitionTimer <= 0)
            {
                transition.enabled = false;
                playerRb.velocity = new Vector3(0f, 0f, 0f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _playerGodMode = other.GetComponentInParent<PlayerCheats>().godModeActivated;
            
            if (_playerGodMode) return;
            
            _transitionTimer = transitionCoolDown;
            transition.enabled = true;

            playerRb.velocity = new Vector3(0f, 0f, 0f);
            _grapplingBeha.StopGrapple();
            player.transform.position = checkPoint.position;
            
            if (_swingBeha)
            {
                StartCoroutine(_swingBeha.StopSwing());
            }
        }
    }
}