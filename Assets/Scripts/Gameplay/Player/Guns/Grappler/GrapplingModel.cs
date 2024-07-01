using UnityEngine;

namespace Gameplay.Player.Guns.Grappler
{
    [CreateAssetMenu(fileName = "GrapplingModel", menuName = "Models/Guns/Grappler")]
    public class GrapplingModel : ScriptableObject
    {
        [Header("Grappling Properties")]
        [Tooltip("The maximum distance the grappling hook can reach.")]
        [SerializeField] private float maxGrappleDistance;

        [Tooltip("The delay time before the grappling hook can be used again.")]
        [SerializeField] private float grappleDelayTime;

        [Tooltip("The overshoot distance on the Y-axis when grappling.")]
        [SerializeField] private float overshootYAxis;

        [Tooltip("The cooldown time between grappling attempts.")]
        [SerializeField] private float grapplingCd;

        [Tooltip("The duration the grappling hook stays active.")]
        [SerializeField] private float grappleDuration;

        [Tooltip("The layer mask for determining what objects are grappleable.")]
        [SerializeField] private LayerMask grappeable;
        public float MaxGrappleDistance => maxGrappleDistance;
        public float GrappleDelayTime => grappleDelayTime;
        public float OvershootYAxis => overshootYAxis;
        public float GrapplingCd => grapplingCd;
        public float GrappleDuration => grappleDuration;
        public LayerMask Grappeable => grappeable;
    }
}