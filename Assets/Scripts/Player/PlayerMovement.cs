using System.Collections;
using System.Collections.Generic;
using FunkyCode.Rendering.Day;
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
    private bool facingRight = true;
    private bool facingUp = false;
    private bool facingDown = false;

    [HideInInspector] public UnityEvent OnPlayerMove;
    [HideInInspector] public UnityEvent OnPlayerStop;
    private bool allowPlayerInput = false;
    private PlayerAnimations playerAnims; 

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<InputControls>();
        rb = GetComponent<Rigidbody2D>();
        playerAnims = GetComponentInChildren<PlayerAnimations>();
        playerAnims.OnSpawnAnimationEnd.AddListener(AllowPlayerInputOnAnimationEnd);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(allowPlayerInput == false)
            return;
        moveInput = playerInput.movement.ReadValue<Vector2>();
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, moveInput, ref movementInputSmoothVelocity, SMOOTH_TIME);
        rb.velocity = smoothedMovementInput * moveSpeed;
  


        if (isCurrentlyMoving)
        {
            if (!IsPlayerMoving())
            {
                ResetRotation();
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

    private void Update()
    {
        FlipPlayer();
    }



    public void FlipPlayer()
    {
        
        if (moveInput.y > 0 && facingUp)
        {
            //ResetRotation();
            //RotatePlayerUp();
        }
        else if (moveInput.y < 0 && !facingUp)
        {
           // ResetRotation();
            //FlipPlayerDown();
        }
       if (moveInput.x < 0 && facingRight)
        {
            ResetRotation();
            FlipPlayerLeftNRight();
        }
       else if (moveInput.x > 0 && !facingRight)
        {
            ResetRotation();
            FlipPlayerLeftNRight();
        }

        

    }

    public void FlipPlayerLeftNRight()
    {
        Vector2 playerScale = transform.localScale;
        playerScale.x *= -1;
        gameObject.transform.localScale = playerScale;

        facingRight = !facingRight;
    }

    public void RotatePlayerUp()
    {
        /*Vector2 playerScale = transform.localScale;
        playerScale.y *= -1;
        gameObject.transform.localScale = playerScale;*/

        transform.rotation = Quaternion.Euler(0, 0, 90);
        facingUp = !facingUp;

     
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void FlipPlayerDown()
    {
        

        transform.rotation = Quaternion.Euler(0, 0, -90);

        facingUp = !facingUp;
    }

    

    public void AllowPlayerInputOnAnimationEnd()
    {
        allowPlayerInput = true;
    }

    public bool IsPlayerMoving()
    {
        return moveInput != Vector2.zero;
    }

}
