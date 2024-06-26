using System;
using UnityEngine;

namespace Guns.Swing
{
    public class HitPointManager : MonoBehaviour
    {
        [SerializeField] private SwingModel model;
        [SerializeField] private MeshRenderer pointPrefab;
        [SerializeField] private AnimationCurve sizeCurve;
        private float _size;
        private MeshRenderer _point;
        private UnityEngine.Camera _camera;

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void OnEnable()
        {
            _point = Instantiate(pointPrefab);
        }

        private void OnDisable()
        {
            if(_point != null && _point.gameObject != null)
                Destroy(_point.gameObject);
        }

        private void Update()
        {
            if (!_camera) return;
            
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hit, model.MaxSwingDistance,
                    model.Grappeable))
            {
                _point.transform.position = hit.point;
                _size = sizeCurve.Evaluate(hit.distance / model.MaxSwingDistance);
                _point.transform.localScale = Vector3.one * _size;
                _point.enabled = true;
            }
            else
            {
                _point.enabled = false;
            }
        }
    }
}
