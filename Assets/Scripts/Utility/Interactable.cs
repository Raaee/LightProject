using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage; // Message that displays when in range of an interactable
    
    [Header("Debug")]
    // this is so the interaction does not get called a million times per click
    [SerializeField] protected bool interacted = false; 

    // this will be called by player
    public void BaseInteract() {
        if (interacted) return;
        Interact();
        interacted = true;
    }
    protected virtual void Interact() {
        // this will be overridden
    }
}
