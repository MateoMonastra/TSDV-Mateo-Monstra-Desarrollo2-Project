using UnityEngine;

namespace Gameplay.Player.Running
{
    [CreateAssetMenu(fileName = "RunningModel", menuName = "Models/Player/Running")]
    public class RunningModel : ScriptableObject
    {
        
        [Header("On Ground")]
        [Tooltip("The running speed of the character.")]
        public float speed;
    
        [Tooltip("The acceleration rate of the character.")]
        [SerializeField] private float acceleration = 10;
    
        [Tooltip("The braking multiplier applied when the character stops running.")]
        [SerializeField] private float brakeMultiplier = 0.75f;

        [Header("On Air")]
        [Tooltip("The multiplier applied to movement speed when the character is in the air.")]
        [SerializeField] private float airMultiplier;
        
        public float Acceleration => acceleration;
        public float AirMultiplier => airMultiplier;
        public float BrakeMultiplier => brakeMultiplier;
    }
}