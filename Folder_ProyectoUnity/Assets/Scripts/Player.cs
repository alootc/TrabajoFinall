using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float force_jump = 200f;
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;
    private PlayerInput playerInput;

    private Vector2 inputs;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    
    void Update()
    {
        inputs = playerInput.actions["Movement"].ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 movement = inputs * speed;
        rb.velocity = new Vector3(inputs.x, rb.velocity.y, inputs.y) * speed;

    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.AddForce(Vector3.up *  force_jump);
        }
    }
}
