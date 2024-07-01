using UnityEngine;

namespace Player.Running
{
    [CreateAssetMenu(fileName = "RunningModel", menuName = "Models/Player/Running")]
    public class RunningModel : ScriptableObject
    {
        
        [Header ("OnGround")]
        public float speed;
        [SerializeField] private float acceleration = 10;
        [SerializeField] private float brakeMultiplier = .75f;
        [Header ("OnAir")]
        [SerializeField] private float airMultiplayer;
        
        public float Acceleration => acceleration;
        public float AirMultiplayer => airMultiplayer;
        public float BrakeMultiplier => brakeMultiplier;
    }
}