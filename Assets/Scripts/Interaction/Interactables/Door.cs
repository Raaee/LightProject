using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable {

    [field: SerializeField] public DoorVisual Visual { get; private set; }
    [SerializeField] private bool isPortal = false;
    public void Interact() {
        if (isPortal) {
            // switch level
        } else {

        }
    }
}
