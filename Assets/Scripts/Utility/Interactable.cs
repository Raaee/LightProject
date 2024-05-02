using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactMessageText;
    public string promptMessage = "E/M2 To Interact"; // Message that displays when in range of an interactable
    [SerializeField] protected bool oneTimeUse = true;
    [SerializeField] protected float timeToResetInteractedState = 0.75f;

    [field: Header("Debug")]
    [field: SerializeField] public bool Interacted { get; protected set; }
    // this ^ is so the interaction does not get called a million times per click

    private void Start() {
        if (oneTimeUse) timeToResetInteractedState = 0f;
        DisablePromptMessage();
    }

    // this will be called by interaction system
    public void BaseInteract() {
        if (oneTimeUse && Interacted) return;
        if (Interacted) return;
        Interact();
        DisableInteraction();
        if (!oneTimeUse) {
            StartCoroutine(ResetInteractionState());
        }
    }
    public void DisableInteraction() {
        Interacted = true;
        DisablePromptMessage();
    }
    public void EnableInteraction() {
        Interacted = false;
    }
    public void EnablePromptMessage() {
        interactMessageText.text = promptMessage;
    }
    public void DisablePromptMessage() {
        interactMessageText.text = " ";
    }
    public IEnumerator ResetInteractionState() {
        yield return new WaitForSeconds(timeToResetInteractedState);
        EnableInteraction();
    }
    protected virtual void Interact() {
        // this will be overridden
    }
}
