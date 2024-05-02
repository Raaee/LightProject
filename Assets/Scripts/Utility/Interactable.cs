using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage; // Message that displays when in range of an interactable

    // this will be called by player
    public void BaseInteract() {
        Interact();
    }
    protected virtual void Interact() {
        // this will be overridden
    }
}
