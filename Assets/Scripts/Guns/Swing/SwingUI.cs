using Guns.Swing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete]
public class SwingUI : MonoBehaviour
{
    [SerializeField] private SwingModel model;
    [SerializeField] private LayerMask grappable;
    [SerializeField] private MeshRenderer pointPrefab;
    [SerializeField] private AnimationCurve sizeCurve;
    [Obsolete]
    [SerializeField] private float sizeMultiplier = .01f;
    private float size;
    private MeshRenderer point;

    private void OnEnable()
    {
        point = Instantiate(pointPrefab);
    }

    private void OnDisable()
    {
        if(point != null && point.gameObject != null)
            Destroy(point.gameObject);
    }

    private void Update()
    {
        if (Physics.Raycast(UnityEngine.Camera.main.transform.position, UnityEngine.Camera.main.transform.forward, out var hit, model.MaxSwingDistance,
                grappable))
        {
            point.transform.position = hit.point;
            size = sizeCurve.Evaluate(hit.distance / model.MaxSwingDistance);
            point.transform.localScale = Vector3.one * size;
            point.enabled = true;
        }
        else
        {
            point.enabled = false;
        }
    }
}
