using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Coin
{
    public class LevelManager : MonoBehaviour
    {
        enum Levels
        {
            Level0,
            Level1,
            Level2,
            Level3
        }

        [SerializeField] private Levels currentLevel;

        [SerializeField] private List<Coin> coins;
        [SerializeField] private Collider player;

        void Start()
        {
            currentLevel = Levels.Level1;
        }

        void Update()
        {
            WinCondition();
        }

        private void WinCondition()
        {
            int coinCount = 0;
            
            foreach (var coin in coins)
            {
                if (coin.isActive)
                {
                    coinCount++;
                }
            }
            if (coins.Count == 0)
            {
                currentLevel++;
            }
        }

        private void ChangeLevel()
        {
            
        }
        private void InitLevel()
        {
            
        }
    }
}