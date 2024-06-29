using UnityEngine;

namespace Coin
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "Models/Coin/CoinData")]
    public class CoinData : ScriptableObject
    {
        [SerializeField] private Vector3 position;
        [SerializeField] private Vector3 scale;

        public Vector3 Position => position;
        public Vector3 Scale => scale;
    }
}