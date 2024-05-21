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
            currentLevel = Levels.Level0;
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
            if (coinCount == 0)
            {
                currentLevel++;
                if (currentLevel>Levels.Level3)
                {
                    SceneManager.LoadScene(0);
                }
                ChangeLevel((int)currentLevel);
            }
        }

        private void ChangeLevel(int indice)
        {
            SceneManager.LoadScene(indice);
        }
    }
}