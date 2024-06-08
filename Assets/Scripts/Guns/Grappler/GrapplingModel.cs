using UnityEngine;
using UnityEngine.Serialization;

namespace Guns.Grappler
{
    [CreateAssetMenu(fileName = "GrapplingModel", menuName = "Models/Guns/Grappler")]
    public class GrapplingModel : ScriptableObject
    {
        [SerializeField] private float maxGrappleDistance;
        [SerializeField] internal float grappleDelayTime;
        [SerializeField] internal float overshootYAxis;
        [SerializeField] internal float grapplingCd;
        public float MaxGrappleDistance => maxGrappleDistance;
    }
}