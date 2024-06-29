using UnityEngine;
using UnityEngine.Serialization;

namespace Guns.Grappler
{
    [CreateAssetMenu(fileName = "GrapplingModel", menuName = "Models/Guns/Grappler")]
    public class GrapplingModel : ScriptableObject
    {
        [SerializeField] private float maxGrappleDistance;
        [SerializeField] private float grappleDelayTime;
        [SerializeField] private float overshootYAxis;
        [SerializeField] private float grapplingCd;
        [SerializeField] private LayerMask grappeable;
        public float MaxGrappleDistance => maxGrappleDistance;
        public float GrappleDelayTime => grappleDelayTime;
        public float OvershootYAxis => overshootYAxis;
        public float GrapplingCd => grapplingCd;
        public LayerMask Grappeable => grappeable;
    }
}