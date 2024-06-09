using System;
using UnityEngine;

namespace Guns
{
    public class HitPoint : MonoBehaviour
    {
        private Transform _point;
        private void OnEnable()
        {
            _point = GetComponent<Transform>();
        }

        public void MovePoint(Vector3 position)
        {
            if (_point.position == position) return;
            
            _point.position = position;
        }

        public void ResetPoint()
        {
            if (_point.position == Vector3.zero) return;
            
            _point.position = Vector3.zero;
        }
    }
}
