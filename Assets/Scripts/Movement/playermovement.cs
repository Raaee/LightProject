using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private InputControls playerInput;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<InputControls>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = playerInput.movement.ReadValue<Vector2>();
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, moveInput, ref movementInputSmoothVelocity, 0.1f);
        rb.velocity = smoothedMovementInput * speed;
    }

}
