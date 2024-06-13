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
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
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
