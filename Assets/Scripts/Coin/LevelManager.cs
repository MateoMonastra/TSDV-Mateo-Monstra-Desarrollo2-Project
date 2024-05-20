using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coin
{
    public class LevelManager : MonoBehaviour
    {
        enum Levels
        {
            Level1,
            Level2,
            Level3,
            Level4
        }

        [SerializeField] private Levels currentLevel;

        [SerializeField] private List<Coin> coins;
        [SerializeField] private Collider player;
        [SerializeField] 

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
            if (coins.Count == 0)
            {
                currentLevel++;
            }
        }

        private void InitLevel()
        {
            
        }

        private void WipeLevel()
        {
        }
    }
}