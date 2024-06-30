using UnityEngine;

namespace Guns.Swing
{
    [CreateAssetMenu(fileName = "SwingModel", menuName = "Models/Guns/Swinger")]
    public class SwingModel : ScriptableObject
    {
        [SerializeField] private float maxSwingDistance;
        [SerializeField] private float swingDelayTime;
        [SerializeField] private float swingCd;
        [SerializeField] private float maxDistance;
        [SerializeField] private float minDistance;
        [SerializeField] private float spring;
        [SerializeField] private float damper;
        [SerializeField] private float massScale;
        [SerializeField] private LayerMask grappeable;
    
        public float MaxSwingDistance => maxSwingDistance;
        public float SwingDelayTime => swingDelayTime;
        public float SwingCd => swingCd;
        public float MaxDistance => maxDistance;
        public float MinDistance => minDistance;
        public float Spring => spring;
        public float Damper => damper;
        public float MassScale => massScale;
        public LayerMask Grappeable => grappeable;
    }
}
