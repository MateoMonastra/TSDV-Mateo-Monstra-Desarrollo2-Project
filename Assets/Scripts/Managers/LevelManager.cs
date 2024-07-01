using System.Collections.Generic;
using EventSystems;
using EventSystems.EventSoundManager;
using HighScore;
using UnityEngine;
using Timer = LevelManager.Timer;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private EventChannelSceneManager eventChanel;

        [SerializeField] private List<LevelData.LevelData> levels;
        [SerializeField] private LevelData.LevelData currentLevel;
        [SerializeField] private string returnScene = "HighScores";

        [Tooltip("List for Pool of Coins")] [SerializeField]
        private List<Coin.Coin> coins = new List<Coin.Coin>();

        [SerializeField] private HighScoreData highScore;
        [SerializeField] private Timer timer;
        
        [Header("Audio SFX:")] 
        [SerializeField] private EventChannelSoundManager channel;
        [SerializeField] private AudioClip finishLevelClip;

        public bool passLevel;
        private void Start()
        {
            SetMouseForGameplay();

            if (!CheckLevelExistence(currentLevel.SceneName)) return;
            LoadLevel();
        }

        private void Update()
        {
            if (!passLevel)
            {
                if (!CheckLevelIsOver() || currentLevel.SceneName == returnScene) return;
            }
            else
            {
                passLevel = false;
            }

            eventChanel.RemoveScene(currentLevel.SceneName);

            if (currentLevel.NextLevel != returnScene)
            {
                currentLevel = UpdateCurrentLevelData();
                LoadLevel();
            }
            else
            {
                ReturnFromGameplay();
            }
        }

        private bool CheckLevelExistence(string newLevel)
        {
            for (var index = 0; index < levels.Count; index++)
            {
                var level = levels[index];
                if (level.SceneName == newLevel)
                {
                    return true;
                }
            }

            return false;
        }

        private void LoadLevel()
        {
            eventChanel.AddScene(currentLevel.SceneName);

            currentLevel = GetCurrentLevelData();

            SetCoinsNewTransform();
        }

        private LevelData.LevelData UpdateCurrentLevelData()
        {
            foreach (var level in levels)
            {
                if (level.SceneName == currentLevel.NextLevel)
                {
                    return level;
                }
            }

            Debug.Log("Level not found");
            return null;
        }

        private LevelData.LevelData GetCurrentLevelData()
        {
            foreach (var level in levels)
            {
                if (level.SceneName == currentLevel.SceneName)
                {
                    return level;
                }
            }

            Debug.Log("Level not found");
            return null;
        }

        private bool CheckLevelIsOver()
        {
            foreach (var coin in coins)
            {
                if (coin.isActive)
                {
                    return false;
                }
            }
            channel.PlaySound(finishLevelClip);
            Debug.Log("Finish Level");
            return true;
        }

        private void SetMouseForGameplay()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void SetMouseForMenus()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void SetCoinsNewTransform()
        {
            foreach (var newCoinPos in currentLevel.coinPositionData)
            {
                bool wasPositioned = false;

                foreach (var coin in coins)
                {
                    if (!coin.isActive && !wasPositioned)
                    {
                        coin.gameObject.SetActive(true);
                        coin.isActive = true;
                        coin.SetNewTransform(newCoinPos);

                        wasPositioned = true;
                    }
                }
            }
        }

        private void ReturnFromGameplay()
        {
            SetMouseForMenus();
            highScore.AddNewHighScore(timer.TotalTime);
            eventChanel.RemoveScene(gameObject.scene.name);
            eventChanel.AddScene(returnScene);
        }
    }
}