using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;

public class InputControls : MonoBehaviour
{
    public InputAction movement;
    public InputAction interact;
    [SerializeField] private float interactDelayTime = 0.2f;
    private bool interactHeld = false;
    private bool alreadyHeld = false;
    [HideInInspector] public UnityEvent OnInteract;

    [Header("Player Inputs")] public PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Update()
    {
        interact.canceled += ReleasingInteract;  
        interact.started += HoldingInteract;
        interact.performed += Interact;
    }

    public void OnEnable()
    {
        movement = playerControls.Player.Move;
        interact = playerControls.Player.Interact;

        EnableControls();
    }

    public void DisableControls()
    {
        movement.Disable();
        interact.Disable();
    }

    public void EnableControls()
    {
        movement.Enable();
        interact.Enable();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (alreadyHeld) return;
        StartCoroutine(Interaction());        
    }
    private IEnumerator Interaction() {
        while (interactHeld) {
            alreadyHeld = true;
            yield return new WaitForSeconds(interactDelayTime);
            OnInteract.Invoke();
        }
        alreadyHeld = false;
    }
    public void HoldingInteract(InputAction.CallbackContext context) {
        interactHeld = true;
    }
    public void ReleasingInteract(InputAction.CallbackContext context) {
        interactHeld = false;
    }
}