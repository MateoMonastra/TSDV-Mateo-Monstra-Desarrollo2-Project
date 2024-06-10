using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkIdle : States
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float acceleration = 10;
    [SerializeField] private float airMultiplayer = 0.5f;
    [SerializeField] private float brakeMultiplier = .75f;

    [Header("Orientation: ")]
    [SerializeField] private Transform orientation;

    private Vector3 _moveDirection;
    private Rigidbody _rb;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");

        float z = Input.GetAxisRaw("Vertical");


        _moveDirection = orientation.forward * z + orientation.right * x;

    }

    private void FixedUpdate()
    {
        _rb.AddForce(_moveDirection.normalized * (speed * acceleration), ForceMode.Force);
    }
}
