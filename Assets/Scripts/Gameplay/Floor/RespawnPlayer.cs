using EventSystems.EventTimer;
using UnityEngine;

namespace Gameplay.Floor
{
    public class RespawnPlayer : MonoBehaviour
    {
        [SerializeField] private bool activateLogs;

        [Tooltip("Reference of the player GameObject")] 
        [SerializeField] private GameObject player;

        [Tooltip("Reference of the transition GameObject")] 
        [SerializeField] private GameObject transition;

        [Tooltip("transition cooldown variable")] 
        [SerializeField] private float transitionCoolDown;

        [Header("Timer References")] 
        [SerializeField] private EventChannelTimer eventChannelTimer;
        [SerializeField] private float timeToAdd = 20.0f;

        public Transform CheckPoint
        {
            get => _checkPoint;
            set => _checkPoint = value;
        }
        
        private Rigidbody _playerRb;
        private float _transitionTimer;
        private Transform _checkPoint;


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
            if (eventChannelTimer)
                eventChannelTimer.AddTime(timeToAdd);

            _transitionTimer = transitionCoolDown;

            transition.gameObject.SetActive(true);

            _playerRb.velocity = new Vector3(0f, 0f, 0f);

            player.transform.position = _checkPoint.position;

            if (activateLogs)
                Debug.Log("Player Respawned");
        }
    }
}