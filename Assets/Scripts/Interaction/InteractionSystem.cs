using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interaction System class, when the player presses the interaction button, cast a raycast sphere 
/// and interact with any interactables in range 
/// </summary>
public class InteractionSystem : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 4f)] private float interactRadius = 1.5f;
    private InputControls input;
    private void Start() {
        input = GetComponent<InputControls>();
        input.OnInteract.AddListener(HandleInteract);
    }
    private void HandleInteract()
    {
        Collider2D[] collidersInRange = Physics2D.OverlapCircleAll(transform.position, interactRadius);

        foreach (Collider2D col in collidersInRange) {
            IInteractable potentialInteractable = col.gameObject.GetComponent<IInteractable>();
            if (potentialInteractable == null) {
              
                continue;
            }
            potentialInteractable.Interact();
        }
    }
    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Color gizmoColor = Color.yellow;
        gizmoColor.a = 0.2f;
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, interactRadius);
    }

}