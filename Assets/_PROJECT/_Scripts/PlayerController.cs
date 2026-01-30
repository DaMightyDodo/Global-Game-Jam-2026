using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController _controller;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _sprintSpeed = 5f;
    private float _verticalVelocity;
    [Header("Input")]
    private float _moveInput;
    private float _turnInput;
    private bool _jumpInput;
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        GroundMovement();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(_turnInput, 0, _moveInput);
        move *= _walkSpeed;
        move.y = VerticalForceCalculation();
        _controller.Move(move * Time.deltaTime);
    }

    private float VerticalForceCalculation()
    {
        if (_controller.isGrounded)
        {
            _verticalVelocity = -1f;

            if (_jumpInput)
            {
                _verticalVelocity = Mathf.Sqrt(_jumpHeight * _gravity * 2);
                _jumpInput = false;
            }
        }
        else
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }
        return _verticalVelocity;
    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _turnInput = input.x;
        _moveInput = input.y;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && _controller.isGrounded)
        {
            _jumpInput = true;
        }
    }
}