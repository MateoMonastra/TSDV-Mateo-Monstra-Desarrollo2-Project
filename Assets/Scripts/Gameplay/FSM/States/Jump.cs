using System.Collections.Generic;
using UnityEngine;

namespace FSM.States
{
    public class Jump : State
    {

        private Rigidbody _rb;
        private float jumpForce;

        public override void OnStart()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Update()
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        }

        public void FixedUpdate()
        {
             _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        
    }
}
