using UnityEngine;

namespace Player.PlayerCam
{
    [CreateAssetMenu(fileName = "PlayerCamModel", menuName = "Models/Player/Cam")]
    public class PlayerCamModel : ScriptableObject
    {
        [SerializeField] private float sensX;
        [SerializeField] private float sensY;

        public float SensX => sensX;
        public float SensY => sensY;
    }
}
