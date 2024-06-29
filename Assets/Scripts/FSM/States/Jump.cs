using System.Collections.Generic;
using UnityEngine;

namespace FSM.States
{
    public class Jump : States
    {

        private Rigidbody _rb;
        private float jumpForce;

        public override void OnEnabled()
        {
            // _rb = GetComponent<Rigidbody>();
        }

        public override void Update()
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        }

        public override void FixedUpdate()
        {
            // _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }


        public Jump(List<States> possibleTransitions) : base(possibleTransitions)
        { }
    }
}
