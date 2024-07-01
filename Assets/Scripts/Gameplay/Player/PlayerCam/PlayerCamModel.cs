using UnityEngine;

namespace Gameplay.Player.PlayerCam
{
    [CreateAssetMenu(fileName = "PlayerCamModel", menuName = "Models/Player/Cam")]
    public class PlayerCamModel : ScriptableObject
    {
        public float sensX;
        public float sensY;
    }
}