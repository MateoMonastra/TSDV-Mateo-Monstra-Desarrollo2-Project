using UnityEngine;

namespace Guns.Swing
{
    [CreateAssetMenu(fileName = "SwingModel", menuName = "Models/Guns/Swinger")]
    public class SwingModel : ScriptableObject
    {
        [SerializeField] private float maxSwingDistance;
        [SerializeField] private float swingCd;
        [SerializeField] private float maxDistance;
        [SerializeField] private float minDistance;
        [SerializeField] private float spring;
        [SerializeField] private float damper;
        [SerializeField] private float massScale;

    
        public float GetMaxSwingDistance()
        {
            return maxSwingDistance;
        }
        public float GetSwingCd()
        {
            return swingCd;
        }
        public float GetMaxDistance()
        {
            return maxDistance;
        }
        public float GetMinDistance()
        {
            return minDistance;
        }
        public float GetSpring()
        {
            return spring;
        }
        public float GetDamper()
        {
            return damper;
        }
        public float GetMassScale()
        {
            return massScale;
        }
    }
}
