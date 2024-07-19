using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interaction System class, when the player presses the interaction button, cast a raycast sphere 
/// and interact with any interactables in range 
/// </summary>
public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private LayerMask interactablesLayerMask;
    [SerializeField] [Range(0.01f, 4f)] private float interactRadius = 0.75f;
    private float interactionDistanceMultiplier = 0.5f;
    private InputControls input;
    private Collider2D[] collidersInRange;
    private void Start() {
        input = GetComponent<InputControls>();
        Physics2D.queriesStartInColliders = false;
        input.OnInteract.AddListener(HandleInteract);
    }
    private void Update() {
        collidersInRange = Physics2D.OverlapCircleAll(transform.position, interactRadius, interactablesLayerMask);
        foreach (Collider2D col in collidersInRange) {
            InteractVisual potentialInteractVisual = col.gameObject.GetComponentInChildren<InteractVisual>();
            if (!potentialInteractVisual) {

                continue;
            }
            float distance = Vector2.Distance(transform.position, col.transform.position);
            if (distance <= (interactRadius + interactionDistanceMultiplier)) {
                potentialInteractVisual.HighlightSprite();
            }
            else {
                potentialInteractVisual.NormalSprite();
            }
        }
    }
    private void HandleInteract()
    {
        foreach (Collider2D col in collidersInRange) {
            IInteractable potentialInteractable = col.gameObject.GetComponentInChildren<IInteractable>();
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
