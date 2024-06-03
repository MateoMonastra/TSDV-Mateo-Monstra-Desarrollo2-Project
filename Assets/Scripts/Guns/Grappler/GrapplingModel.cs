using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrapplingModel", menuName = "Models/Guns/Grappler")]
public class GrapplingModel : ScriptableObject
{
    [SerializeField] public float maxGrappleDistance { get; private set; }
    [SerializeField] public float grappleDelayTime { get; private set; }
    [SerializeField] public float overshootYAxis { get; private set; }
    [SerializeField] public float grapplingCd { get; private set; }



}
