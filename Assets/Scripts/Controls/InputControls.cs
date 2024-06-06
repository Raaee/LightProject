using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputControls : MonoBehaviour
{
    public InputAction movement;
    public InputAction interact;

    [HideInInspector] public UnityEvent OnInteract;

    [Header("Player Inputs")] public PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Update()
    {
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
        OnInteract.Invoke();
    }
}