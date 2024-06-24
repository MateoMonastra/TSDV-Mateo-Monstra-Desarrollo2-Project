using Player;
using Player.Running;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManager
{
    public class PlayerCheats : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private float flashModeSpeed;

        private RunningBehaviour _playerRb;
        public bool godModeActivated;
        private float _normalSpeed;

        private void Start()
        {
            _playerRb = GetComponent<RunningBehaviour>();
            // _normalSpeed = _playerRb.speed;

            if(levelManager == null)
            {
                foreach(var rootGo in gameObject.scene.GetRootGameObjects())
                {
                    if(rootGo.TryGetComponent<LevelManager>(out var levelManager))
                    {
                        this.levelManager = levelManager;
                        break;
                    }
                }
            }
            if(levelManager == null)
            {
                Debug.LogError($"{name}: {nameof(LevelManager)} not found!");
            }
        }

        public void PassLevel()
        {
            levelManager.currentLevel++;
            
            if (levelManager.currentLevel > LevelManager.Levels.Level2)
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
            // _playerRb.speed = Mathf.Approximately(_playerRb.speed, _normalSpeed) ? flashModeSpeed : _normalSpeed;
        }
    }
}