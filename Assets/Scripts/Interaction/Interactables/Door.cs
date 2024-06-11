using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour {

    [field: SerializeField] public DoorVFX Visual { get; private set; }

    public UnityEvent OnDoorOpened; 
    public bool IsLocked { get; set; }

    private void Start() 
    {
        IsLocked = true;
    }
    public void AlertDoorEvent()
    {
        OnDoorOpened?.Invoke();
    }
 


}
