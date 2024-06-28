using System.Collections.Generic;
using Coin;
using Coin.CoinMode;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Models/Levels/LevelData")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private string sceneName;
        [SerializeField] private string nextLevel;
        // [SerializeField] private CoinMode coinMode;

        public List<CoinData> coinPositionData;
        public string SceneName => sceneName;
        public string NextLevel => nextLevel;
    }
}