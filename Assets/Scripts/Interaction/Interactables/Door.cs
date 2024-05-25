using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    [field: SerializeField] public DoorVisual Visual { get; private set; }
    [SerializeField] private bool isPortal = false;
    public bool IsLocked { get; set; }

    private void Start() {
        IsLocked = true;
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (isPortal && !IsLocked) {
            // switch level
            Debug.Log("Next Level");
        }
    }
}
