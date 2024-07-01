using Gameplay.Player.Guns.Swing;
using UnityEngine;

namespace Gameplay.Player.Guns.HitPoint
{
    public class HitPointManager : MonoBehaviour
    {
        [Header("Swing Settings")]
        [Tooltip("The swing model containing swing parameters.")]
        [SerializeField] private SwingModel model;

        [Tooltip("Prefab for the swing point visual representation.")]
        [SerializeField] private MeshRenderer pointPrefab;

        [Tooltip("Animation curve for scaling the swing point based on distance.")]
        [SerializeField] private AnimationCurve sizeCurve;

        [Tooltip("Reference to the ground check component.")]
        [SerializeField] private GroundCheck groundCheck;
        
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
                    model.Grappeable) && !groundCheck.IsOnGround())
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
