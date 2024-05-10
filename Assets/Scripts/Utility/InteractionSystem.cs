using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Interaction System class has the player's raycast sphere that allows interaction with interactable objects
/// </summary>
public class InteractionSystem : MonoBehaviour
{
    private InputControls input;
    [SerializeField] [Range(0.01f, 4f)]private float interactRadius = 1.5f;
    private void Start() {
        input = GetComponent<InputControls>();
        input.OnInteract.AddListener(HandleInteract);
    }
    private void HandleInteract()
    {
        var col2d = Physics2D.OverlapCircleAll(transform.position, interactRadius);
        foreach (var col in col2d) {
            IInteractable potentialInteractable = col.gameObject.GetComponent<IInteractable>();
            if (potentialInteractable == null) {
                Debug.Log("no IIinteractable on " + col.gameObject.name + " brody");
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
