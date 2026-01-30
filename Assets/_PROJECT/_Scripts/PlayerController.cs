using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController _controller;
    
    [Header("Movement")]
    [SerializeField] private float _walkSpeed;
    [Header("Input")]
    private float _moveInput;
    private float _turnInput;

    private void GetInput()
    {
        _moveInput = Input.GetAxis("Vertical");
        _turnInput = Input.GetAxis("Horizontal");
    }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetInput();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(_turnInput, 0, _moveInput);
    }
}
