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
    [SerializeField] private GameObject visualToRotate;
    private Vector2 moveInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;

    private const float SMOOTH_TIME = 0.1f;
    private bool isCurrentlyMoving = false;

    [HideInInspector] public UnityEvent OnPlayerMove;
    private bool playerFirstMoved = false;
    [HideInInspector] public UnityEvent OnPlayerStop;
    private bool allowPlayerInput = false;
    private PlayerAnimations playerAnims;

    [Tooltip("Doesnt play idle or transitioning animations")]
    private bool smoothMovementAnimations = false;
    private float timeToIdle = 1.5f;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<InputControls>();
        rb = GetComponent<Rigidbody2D>();
        playerAnims = GetComponentInChildren<PlayerAnimations>();
        playerAnims.OnSpawnAnimationEnd.AddListener(AllowPlayerInputOnAnimationEnd);
        isCurrentlyMoving = false;
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
            // IDK BUT IT WORKS DONT TOUCH IT
            if (moveInput.x < 0.2f && moveInput.y < 0.2f && moveInput.x < 0.2f && moveInput.y < 0.2f) {
                isCurrentlyMoving = false;
                StartCoroutine(StartIdleTimer());
            }
            if (IsPlayerMoving())
            {
                OnPlayerMove?.Invoke();
                smoothMovementAnimations = true;
                isCurrentlyMoving = true;
                HandleTutorialEvent();
            }
        }
    }

  

    private void Update()
    {
       FlipPlayer();
       allowPlayerInput = true;
    }

    public void FreezePlayer()
    {
        rb.velocity = Vector2.zero;
        
    }
    public void FlipPlayer()
    {
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            visualToRotate.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ResetRotation()
    {
        visualToRotate.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void AllowPlayerInputOnAnimationEnd()
    {
        allowPlayerInput = true;
    }

    public bool IsPlayerMoving()
    {
        if (smoothMovementAnimations)
            return moveInput.x > 0.3f || moveInput.y > 0.3f || moveInput.x < 0.3f || moveInput.y < 0.3f;
        else
            return moveInput != Vector2.zero;
    }

 

    private void HandleTutorialEvent()
    {
        if (!playerFirstMoved)
        {
            playerFirstMoved = true;
            TutorialSystem tutorialSystem = FindObjectOfType<TutorialSystem>();
            tutorialSystem?.OnNextTutorialStep(1);
        }
    }

    private IEnumerator StartIdleTimer() {
        yield return new WaitForSeconds(timeToIdle);
        smoothMovementAnimations = false;
    }
}
