using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Interaction System class has the player's raycast sphere that allows interaction with interactable objects
/// </summary>
public class InteractionSystem : MonoBehaviour
{
    private RaycastHit2D hit;
    private InputControls input;
    private Interactable lastInteractable;
    private void Start() {
        input = GetComponent<InputControls>();
    }
    private void Update() {
        Vector2 currPos = transform.position;
        hit = Physics2D.CircleCast(currPos, 1.5f, currPos);
        if (hit) {
            Interactable potentialInteractable = hit.collider.GetComponent<Interactable>();
            if (potentialInteractable) {
                lastInteractable = potentialInteractable;
                if (!potentialInteractable.Interacted) {
                    potentialInteractable.EnablePromptMessage();
                }
                if (input.interact.IsPressed()) {
                    potentialInteractable.BaseInteract();
                }
            }
        }
        else {
            if (lastInteractable) {
                lastInteractable.DisablePromptMessage();
            }
        }
    }

}
