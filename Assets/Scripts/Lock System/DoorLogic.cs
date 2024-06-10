using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private LayerMask defaultLayerMask;
    [SerializeField] private LayerMask lightBlockingLayerMask;
    [SerializeField] public List<ILock> locks;
    [SerializeField] private bool isLocked;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        isLocked = true;
        foreach (ILock alock in locks)
        {        
            alock.OnInputDetection.AddListener(CheckLockStatus);
        }
    }

    // DoorLogic can cheack the lock status of multiple locks
    public void CheckLockStatus() {
        foreach (ILock alock in locks)
        {
            if (alock.IsLocked) {
                LockDoor();
                return;
            }
        }
        UnlockDoor();
    }

    public void UnlockDoor() {
        isLocked = false;
        door.IsLocked = isLocked;
        door.Visual.PlayOpen();
        door.AlertDoorEvent();
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        this.gameObject.layer = defaultLayerMask;
    }

    public void LockDoor() {
        isLocked = true;
        door.IsLocked = isLocked;
        door.Visual.PlayClose();
        door.AlertDoorEvent();
        this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        this.gameObject.layer = lightBlockingLayerMask;
    }
}
