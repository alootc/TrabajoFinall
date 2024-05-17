using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float upForce = 250f;






    public float speedX;
    public float raycastDistance = 1f;

    public float _xMovement;
    public float _zMovement;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Move()
    {
        rb.velocity = new Vector3(_xMovement * speedX, rb.velocity.y, _zMovement * speedX);
    }

    public void OnMovementX(InputAction.CallbackContext context)
    {
        _xMovement = context.ReadValue<float>();
    }

    public void OnMovementZ(InputAction.CallbackContext context)
    {
        _zMovement = context.ReadValue<float>();
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * upForce);
    }
}
