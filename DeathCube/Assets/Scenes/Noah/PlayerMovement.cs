using System.Collections;
using Newtonsoft.Json;
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
        input.Player.Jump.performed += OnJumpPerformed;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.canceled -= OnMovement;
        input.Player.Jump.canceled -= OnJumpPerformed;
    }

    private void FixedUpdate()
    {
        if (jumped)
        {
            jumped = false;
        }
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector3>();

        if (moveVector != Vector3.zero)
        {
            rb.velocity = new Vector3(moveVector.x * moveSpeed, rb.velocity.y, moveVector.z * moveSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (!jumped)
        {
            jumped = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
