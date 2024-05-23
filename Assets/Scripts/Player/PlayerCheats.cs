using System;
using Coin;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerCheats : MonoBehaviour
    {
        [SerializeField] private LevelManager.LevelManager levelManager;
        [SerializeField] private float flashModeSpeed;

        private RunningBehaviour _playerRb;
        public bool godModeActivated;
        private float _normalSpeed;

        private void Start()
        {
            _playerRb = GetComponent<RunningBehaviour>();
            _normalSpeed = _playerRb.speed;
        }

        public void PassLevel()
        {
            levelManager.currentLevel++;
            if (levelManager.currentLevel > LevelManager.LevelManager.Levels.Level3)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(0);
            }
            else
            {
                levelManager.ChangeLevel((int)levelManager.currentLevel);
            }
        }

        public void GodMode()
        {
            godModeActivated = !godModeActivated;
        }

        public void FlashMode()
        {
            _playerRb.speed = Mathf.Approximately(_playerRb.speed, _normalSpeed) ? flashModeSpeed : _normalSpeed;
        }
    }
}