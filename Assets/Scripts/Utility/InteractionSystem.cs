using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    private RaycastHit2D hit;
    private InputControls input;

    private void Start() {
        input = GetComponent<InputControls>();
    }
    private void Update() {
        Vector2 currPos = transform.position;
        hit = Physics2D.CircleCast(currPos, 1.5f, currPos);
        if (hit) {
            Interactable potentialInteractable = hit.collider.GetComponent<Interactable>();
            if (potentialInteractable) {
                Debug.Log(potentialInteractable.promptMessage);
                if (input.interact.IsPressed()) {
                    potentialInteractable.BaseInteract();
                }
            }
        }
    }

}
