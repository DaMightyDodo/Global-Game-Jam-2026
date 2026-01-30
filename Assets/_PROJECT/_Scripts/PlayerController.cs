using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController _controller;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 5f;

    [Header("Input")]
    private float _moveInput;
    private float _turnInput;

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
        _controller.Move(move * Time.deltaTime);
    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _turnInput = input.x;
        _moveInput = input.y;
    }
}