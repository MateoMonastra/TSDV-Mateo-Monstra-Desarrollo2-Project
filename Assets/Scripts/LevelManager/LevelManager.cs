using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManager
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

        enum CoinMode
        {
            Normal,
            CoinRun
        }

        enum LevelMode
        {
            Normal,
            TimeTrial
        }


        [SerializeField] private CoinMode coinMode;
        [SerializeField] private LevelMode levelMode;
        [SerializeField] private List<Coin.Coin> coins;
        [SerializeField] private Timer timer;

        public Levels currentLevel;
        int _currentCoin = 0;


        private void Start()
        {
            if (levelMode == LevelMode.TimeTrial)
            {
                var canvas = timer.GetComponentInChildren<Canvas>();
                canvas.enabled = true;
                timer.enabled = true;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            switch (coinMode)
            {
                case CoinMode.Normal:
                    NormalMode();
                    break;
                case CoinMode.CoinRun:
                    CoinRushMode();
                    break;
                default:
                    break;
            }

            if (levelMode == LevelMode.TimeTrial) 
            {
                if (timer.TimerFinished()) 
                {
                    ChangeLevel((int)currentLevel);
                }
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

            coins[_currentCoin].ActivateCoin();

            if (!coins[_currentCoin].isActive)
            {
                _currentCoin++;

                if (_currentCoin == coins.Count)
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
                    coins[_currentCoin].ActivateCoin();
                }
            }
        }
    }
}