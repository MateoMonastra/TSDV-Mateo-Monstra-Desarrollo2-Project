using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : States
{
    Rigidbody _rb;
    float jumpForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            //_rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
