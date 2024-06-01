using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(1f, 20f)] private float moveSpeed = 6f;

    private InputControls playerInput;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;

    private const float SMOOTH_TIME = 0.1f;
    private bool isCurrentlyMoving = false;

    [HideInInspector] public UnityEvent OnPlayerMove;
    [HideInInspector] public UnityEvent OnPlayerStop;
   

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
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, moveInput, ref movementInputSmoothVelocity, SMOOTH_TIME);
        rb.velocity = smoothedMovementInput * moveSpeed;

        if(isCurrentlyMoving)
        {
            if (!IsPlayerMoving())
            {
                OnPlayerStop?.Invoke();
                isCurrentlyMoving = false;
            }
           
        }
        else
        {
            if (IsPlayerMoving())
            {
                OnPlayerMove?.Invoke();
                isCurrentlyMoving = true;
            }
        }
      
       
    }


    public bool IsPlayerMoving()
    {
        return moveInput != Vector2.zero;
    }

}
