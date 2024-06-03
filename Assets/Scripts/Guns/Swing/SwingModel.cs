using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwingModel", menuName = "Models/Guns/Swinger")]
public class SwingModel : ScriptableObject
{
    [SerializeField] private float maxSwingDistance;

    [SerializeField] private float swingCd;
    [SerializeField] public float maxDistance;
    [SerializeField] public float minDistance;
    [SerializeField] public float spring;
    [SerializeField] public float damper;
    [SerializeField] public float massScale;

    public float GetmaxSwingDistance() 
    {
        return maxSwingDistance;
    }

    public float GetSwingCd()
    {
        return swingCd;
    }

    public float GetmaxDistance() 
    {
        return maxDistance;
    }

    public float GetminDistance()
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
