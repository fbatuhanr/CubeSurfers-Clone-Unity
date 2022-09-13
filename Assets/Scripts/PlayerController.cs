using System;
using NaughtyAttributes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float inputSpeed;
    [SerializeField] private float movementSpeed;

    private float HorizontalInput => _joystick.Horizontal;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _rigidbody.velocity = new Vector3(HorizontalInput*inputSpeed, 0, movementSpeed);
    }

}
