using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Rigidbody _rb;
    public float _walkSpeed = 5f;
    public float _jumpForce = 5f;
    public Vector2 _moveInput;
    public Vector3 _jumpInput;

    void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move Input: " + _moveInput);
    }
    public void OnJump(InputAction.CallbackContext context)
    { 
        if(context.performed)
        {
            _rb.AddForce(new Vector3(0,_jumpForce,0), ForceMode.Impulse);
        }
        Debug.Log("Jump Input: " + _jumpInput);
    }

    public void HandlePlayerMovement()
    {
        _rb.MovePosition(_rb.position + new Vector3(_moveInput.x, 0, _moveInput.y) * _walkSpeed * Time.fixedDeltaTime);
    }
}
