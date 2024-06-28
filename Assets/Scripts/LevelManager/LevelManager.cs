using System;
using System.Collections.Generic;
using EventSystems;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelManager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private EventChannel eventChanel;
        
        [SerializeField] private List<LevelData.LevelData> levels;
        [SerializeField] private LevelData.LevelData currentLevel;
        
        [Tooltip("List for Pull of Coins")]
        [SerializeField] private List<Coin.Coin> coins = new List<Coin.Coin>();

        private string _returnMenu = "Menu";
        private void Start()
        {
            SetMouseForGameplay();

            if (!CheckLevelExistence(currentLevel.SceneName)) return;
            LoadLevel();
        }
        private void Update()
        {
            if (!CheckLevelIsOver() || currentLevel.SceneName == _returnMenu) return;
            
            Debug.Log("Termino nivel");
                
            eventChanel.UnLoadScene(currentLevel.SceneName);
            Debug.Log("Descargado");
                
            currentLevel = UpdateCurrentLevelData();
           
            LoadLevel();
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
                
                if(currentLevel.NextLevel == _returnMenu)
                {
                    ReturnMenu();
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
            Debug.Log("Finish Level");
            return true;
        }
        private void SetMouseForGameplay()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void SetMouseForMenu()
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
        private void ReturnMenu()
        {
                SetMouseForMenu();
                eventChanel.UnLoadScene(gameObject.scene.name);
                eventChanel.AddScene(_returnMenu);
                Debug.Log("LoadedMenu");
        }
    }
}