using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// Interaction System class has the player's raycast sphere that allows interaction with interactable objects
/// </summary>
public class InteractionSystem : MonoBehaviour
{
    private RaycastHit2D raycastHit;
    private InputControls input;
    private Interactable lastInteractable;
    [SerializeField] [Range(0.01f, 4f)]private float interactRadius = 1.5f;
    private void Start() {
        input = GetComponent<InputControls>();
    }
    private void Update() {
       
        raycastHit = Physics2D.CircleCast(transform.position, 1.5f, transform.position);
        if (raycastHit) {
            Interactable potentialInteractable = raycastHit.collider.GetComponent<Interactable>();
            if (potentialInteractable == null) return;
           
            lastInteractable = potentialInteractable;
            if (!potentialInteractable.Interacted) {
                potentialInteractable.EnablePromptMessage();
            }
            if (input.interact.IsPressed()) { //this should be the initial if statement. if you press interact, do a raycast...
                potentialInteractable.BaseInteract();
            }
            
        }
        else 
        {
            if (lastInteractable) 
            {
                lastInteractable.DisablePromptMessage();
            }
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
