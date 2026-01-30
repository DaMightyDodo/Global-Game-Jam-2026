using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController _controller;
    [SerializeField] private PlayerScriptable _stat;
    private float _verticalVelocity;

    [Header("Input")]
    private float _moveInput;
    private float _turnInput;
    private bool _jumpRequested;
    private float _lastJumpPressedTime;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GroundMovement();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(_turnInput, 0, _moveInput);
        move *= _stat.walkSpeed;

        move.y = VerticalForceCalculation();

        _controller.Move(move * Time.deltaTime);
    }

    private float VerticalForceCalculation()
    {
        if (_controller.isGrounded)
        {
            // Keep grounded
            if (_verticalVelocity < 0)
                _verticalVelocity = -2f;

            // Jump buffering
            if (_jumpRequested && Time.time < _lastJumpPressedTime + _stat.jumpBufferTime)
            {
                _verticalVelocity = Mathf.Sqrt(_stat.jumpHeight * 2f * _stat.gravity);
                _jumpRequested = false;
            }
        }
        else
        {
            // Gravity
            _verticalVelocity -= _stat.gravity * Time.deltaTime;
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
        if (value.isPressed)
        {
            _jumpRequested = true;
            _lastJumpPressedTime = Time.time;
        }
    }
}
