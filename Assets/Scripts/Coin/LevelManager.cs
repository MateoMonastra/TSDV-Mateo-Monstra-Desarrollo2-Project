using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Coin
{
    public class LevelManager : MonoBehaviour
    {
        public enum Levels
        {
            Level0 = 1,
            Level1,
            Level2,
            Level3
        }

        enum LevelMode
        {
            Normal,
            CoinRun
        }

        public Levels currentLevel;
        [SerializeField] private LevelMode levelMode;

        [SerializeField] private List<Coin> coins;
        int currentCoin = 0;

        void Update()
        {
            switch (levelMode)
            {
                case LevelMode.Normal:
                    NormalMode();
                    break;
                case LevelMode.CoinRun:
                    CoinRushMode();
                    break;
                default:
                    break;
            }
        }

        private void NormalMode()
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
                if (currentLevel > Levels.Level3)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene(0);
                }
                else
                {
                    ChangeLevel((int)currentLevel);
                }
            }
        }

        public void ChangeLevel(int indice)
        {
            SceneManager.LoadScene(indice);
        }


        private void CoinRushMode()
        {
            foreach (var coin in coins)
            {
                coin.DesactivateCoin();
            }

            coins[currentCoin].ActivateCoin();

            if (!coins[currentCoin].isActive)
            {
                currentCoin++;

                if (currentCoin == coins.Count)
                {
                    currentLevel++;
                    if (currentLevel > Levels.Level3)
                    {
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        SceneManager.LoadScene(0);
                    }
                    else
                    {
                        ChangeLevel((int)currentLevel);
                    }
                }
                else
                {
                    coins[currentCoin].ActivateCoin();
                }
            }
        }
    }
}