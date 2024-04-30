using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    private RaycastHit2D hit;
    private void Update() {
        Vector2 currPos = transform.position;
        hit = Physics2D.CircleCast(currPos, 1.5f, currPos);
        if (hit) {
            if (hit.collider.CompareTag("Interactable"))
                Debug.Log("Something was hit");
        }
    }

}
