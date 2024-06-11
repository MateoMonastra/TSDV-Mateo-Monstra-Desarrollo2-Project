using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkIdle : States
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float acceleration = 10;
    [SerializeField] private float brakeMultiplier = .75f;

    //[SerializeField] private float airMultiplayer = 0.5f;

    [Header("Orientation: ")]
    [SerializeField] private Transform orientation;

    private Vector3 _moveDirection;
    private Rigidbody _rb;

    private bool _shouldBrake;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedControl();
    }
    public void Move(Vector3 direction)
    {

        if (direction.magnitude < 0.0001f)
        {
            _shouldBrake = true;
        }

        _moveDirection = orientation.forward * direction.z + orientation.right * direction.x;
    }
    private void FixedUpdate()
    {
        _rb.AddForce(_moveDirection.normalized * (speed * acceleration), ForceMode.Force);

        if (!_shouldBrake) return;

        var currentHorizontalVelocity = _rb.velocity;
        currentHorizontalVelocity.y = 0;

        _rb.AddForce(-currentHorizontalVelocity * brakeMultiplier, ForceMode.Impulse);
        _shouldBrake = false;
    }

    private void SpeedControl()
    {
        Vector3 flatSpeed = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        if (!(flatSpeed.magnitude > speed)) return;

        Vector3 limitedSpeed = flatSpeed.normalized * speed;
        _rb.velocity = new Vector3(limitedSpeed.x, _rb.velocity.y, limitedSpeed.z);
    }
}
