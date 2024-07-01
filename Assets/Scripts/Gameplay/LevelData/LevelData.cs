using System.Collections.Generic;
using Gameplay.Coin;
using UnityEngine;

namespace Gameplay.LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Models/Levels/LevelData")]
    public class LevelData : ScriptableObject
    {
        [Tooltip("Name of the scene associated with this level data.")]
        [SerializeField] private string sceneName;
        
        [Tooltip("Name of the next level to transition to after completing this level.")]
        [SerializeField] private string nextLevel;

        public List<CoinData> coinPositionData;
        public string SceneName => sceneName;
        public string NextLevel => nextLevel;
    }
}