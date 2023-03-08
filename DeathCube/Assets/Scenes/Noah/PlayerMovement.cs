using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Rigidbody rb = null;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 jumpvector = Vector3.zero;
    public float moveSpeed = 10f;

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
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovement;
        input.Player.Movement.canceled -= OnMovementCancelled;
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

    void OnJump(InputAction.CallbackContext context)
    {
        
    }
}
