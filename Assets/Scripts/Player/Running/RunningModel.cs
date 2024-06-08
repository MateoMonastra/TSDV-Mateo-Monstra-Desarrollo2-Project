using UnityEngine;

namespace Player.Running
{
    [CreateAssetMenu(fileName = "RunningModel", menuName = "Models/Player/Running")]
    public class RunningModel : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float acceleration = 10;
        [SerializeField] private float airMultiplayer;
        [SerializeField] private float brakeMultiplier = .75f;

        public float Speed => speed;
        public float Acceleration => acceleration;
        public float AirMultiplayer => airMultiplayer;
        public float BrakeMultiplier => brakeMultiplier;
    }
}