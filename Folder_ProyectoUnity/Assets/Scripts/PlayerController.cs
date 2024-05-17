using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float upForce = 90f;
    private float force = 10f;

    private PlayerInput playerInput;
    private Vector2 input;


    //public float speedX;
    //public float raycastDistance = 1f;

    //public float _xMovement;
    //public float _zMovement;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {

        input = playerInput.actions["Move"].ReadValue<Vector2>();

        
    }

    private void FixedUpdate()
    {

        rb.AddForce(new Vector3(input.x, 0f, input.y) * force);

    }

    //void Move()
    //{
    //    rb.velocity = new Vector3(_xMovement * speedX, rb.velocity.y, _zMovement * speedX);
    //}

    //public void OnMovementX(InputAction.CallbackContext context)
    //{
    //    _xMovement = context.ReadValue<float>();
    //}

    //public void OnMovementZ(InputAction.CallbackContext context)
    //{
    //    _zMovement = context.ReadValue<float>();
    //}

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.AddForce(Vector3.up * upForce);
        }
        
    }

}
