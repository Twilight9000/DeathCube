using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Rigidbody rb = null;
    private Vector3 moveVector = Vector3.zero;
    public float moveSpeed = 10f;
    public float jumpForce = 50f;
    private bool jumped = false;

    // Start is called before the first frame update
    void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovement;
        input.Player.Movement.canceled += OnMovementCancelled;
        input.Player.Jump.performed += OnJumpPerformed;
        input.Player.Jump.canceled += OnJumpCancelled;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovement;
        input.Player.Movement.canceled -= OnMovementCancelled;
        input.Player.Jump.performed -= OnJumpCancelled;
        input.Player.Jump.canceled -= OnJumpPerformed;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector3>();
    }
    void OnMovementCancelled(InputAction.CallbackContext context)
    {
        moveVector = Vector3.zero;
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        jumped = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    void OnJumpCancelled(InputAction.CallbackContext context)
    {
        if(jumped == false)
        {
            var forceEffect = context.duration;
            rb.AddForce(Vector3.up * (jumpForce * (float)forceEffect), ForceMode.Impulse);
        }
    }
}
