using System.Collections.Generic;
using EventSystems;
using EventSystems.EventSceneManager;
using EventSystems.EventSoundManager;
using Gameplay.LevelData;
using HighScore;
using UnityEngine;
using Timer = Gameplay.Timer.Timer;

namespace Managers
{
   public class LevelManager : MonoBehaviour
{
    [Tooltip("Event channel for scene management.")]
    [SerializeField] private EventChannelSceneManager eventChanel;
    
    [Tooltip("List of level data representing available levels.")]
    [SerializeField] private List<LevelData> levels;
    
    [Tooltip("Current level data.")]
    [SerializeField] private LevelData currentLevel;
    
    [Tooltip("Scene name to return to after finishing all levels.")]
    [SerializeField] private string returnScene;
    
    [Tooltip("List for Pool of Coins.")]
    [SerializeField] private List<Gameplay.Coin.Coin> coins = new List<Gameplay.Coin.Coin>();
    
    [Tooltip("Reference to the high score data manager.")]
    [SerializeField] private HighScoreData highScore;
    
    [Tooltip("Reference to the timer for save it later.")]
    [SerializeField] private Timer timer;

    [Header("Audio SFX:")]
    [SerializeField] private EventChannelSoundManager channel;
    [SerializeField] private AudioClip finishLevelClip;

    public bool passLevel;

    private void OnEnable()
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
            TurnOffCoins();
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

    /// <summary>
    /// Check if a level with the given scene name exists in the levels list.
    /// </summary>
    /// <param name="newLevel">The scene name of the level to check.</param>
    private bool CheckLevelExistence(string newLevel)
    {
        foreach (var level in levels)
        {
            if (level.SceneName == newLevel)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Load the current level scene and set up coin positions.
    /// </summary>
    private void LoadLevel()
    {
        eventChanel.AddScene(currentLevel.SceneName);
        
        currentLevel = GetCurrentLevelData();
        
        SetCoinsNewTransform();
    }

    /// <summary>
    /// Update the current level data to the next level data based on the current level's next scene name.
    /// </summary>
    private LevelData UpdateCurrentLevelData()
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

    /// <summary>
    /// Retrieve the current level data based on the current level's scene name.
    /// </summary>
    private LevelData GetCurrentLevelData()
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

    /// <summary>
    /// Check if the current level is over by checking if all coins are inactive.
    /// </summary>
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

    /// <summary>
    /// Set the mouse cursor settings for gameplay.
    /// </summary>
    private void SetMouseForGameplay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Set the mouse cursor settings for menus.
    /// </summary>
    private void SetMouseForMenus()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Set the positions of coins in the level based on the current level's coin position data.
    /// </summary>
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

    /// <summary>
    /// Return from gameplay to menus, showing the mouse cursor and adding the return scene.
    /// </summary>
    private void ReturnFromGameplay()
    {
        SetMouseForMenus();
        highScore.AddNewHighScore(timer.TotalTime);
        eventChanel.RemoveScene(gameObject.scene.name);
        eventChanel.AddScene(returnScene);
    }

    /// <summary>
    /// Turn off all coins.
    /// </summary>
    private void TurnOffCoins()
    {
        foreach (var coin in coins)
        {
            coin.isActive = false;
        }
    }
}
}