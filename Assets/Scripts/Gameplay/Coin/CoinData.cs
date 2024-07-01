using UnityEngine;

namespace Gameplay.Coin
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "Models/Coin/CoinData")]
    public class CoinData : ScriptableObject
    {
        [Tooltip("Position of the coin.")]
        [SerializeField] private Vector3 position;
        
        [Tooltip("Scale of the coin.")]
        [SerializeField] private Vector3 scale;

        public Vector3 Position => position;
        public Vector3 Scale => scale;
    }
}