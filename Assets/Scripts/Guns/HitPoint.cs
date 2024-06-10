using System;
using UnityEngine;

namespace Guns
{
    public class HitPoint : MonoBehaviour
    {
        private Transform _point;
        private Vector3 _moveTo;

        public bool ChangePosition { get; set; }
        public Vector3 MoveTo { get; set; }

        private void OnEnable()
        {
            _point = GetComponent<Transform>();
        }

        public void MovePoint()
        {
            if (_point.position == MoveTo) return;
            
            _point.position = MoveTo;
        }

        public void ResetPoint()
        {
            if (_point.position == Vector3.zero) return;
            
            _point.position = Vector3.zero;
        }
    }
}
