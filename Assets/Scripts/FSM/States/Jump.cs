using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : States
{

    private Rigidbody _rb;
    private float jumpForce;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
    }

    private void FixedUpdate()
    {
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }


}
