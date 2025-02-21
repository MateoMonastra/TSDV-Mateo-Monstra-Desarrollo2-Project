using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Player.Guns.Swing
{
    [CreateAssetMenu(fileName = "SwingModel", menuName = "Models/Guns/Swinger")]
    public class SwingModel : ScriptableObject
    {
        [Header("Swing Properties")]
        [Tooltip("The maximum distance the character can swing.")]
        [SerializeField] private float maxSwingDistance;

        [Tooltip("The delay time before the character can swing again.")]
        [SerializeField] private float swingDelayTime;

        [Tooltip("The cooldown time between swings.")]
        [SerializeField] private float swingCd;

        [Tooltip("The maximum distance for swinging.")]
        [SerializeField] private float maxDistance;

        [Tooltip("The minimum distance for swinging.")]
        [SerializeField] private float minDistance;

        [Tooltip("The spring force applied during swinging.")]
        [SerializeField] private float spring;

        [Tooltip("The damping force applied during swinging.")]
        [SerializeField] private float damper;

        [Tooltip("The mass scale applied to the character during swinging.")]
        [SerializeField] private float massScale;
        
        [Tooltip("The layer mask for determining what objects are grabbable.")]
        [SerializeField] private LayerMask grabbable;
    
        public float MaxSwingDistance => maxSwingDistance;
        public float SwingDelayTime => swingDelayTime;
        public float SwingCd => swingCd;
        public float MaxDistance => maxDistance;
        public float MinDistance => minDistance;
        public float Spring => spring;
        public float Damper => damper;
        public float MassScale => massScale;
        public LayerMask Grabbable => grabbable;
    }
}
