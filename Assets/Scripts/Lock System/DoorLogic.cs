using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField]private List<ILock> locks;

    [SerializeField] private bool isLocked;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        isLocked = true;
        foreach (LaserLock alock in locks)
        {
            alock.IsLocked = true;
            alock.OnlaserDetected.AddListener(CheckLockStatus);
        }
    }

    // In DoorLogic it can cheack the lock status of multiple lock[red, blue, yellow, green] 
    public void CheckLockStatus() {
        foreach (LaserLock alock in locks)
        {
            if (alock.IsLocked) {
                Debug.Log("Door Lock");
                LockDoor();
                return;
            }
        }
        UnlockDoor();
    }

    public void UnlockDoor() {
        isLocked = false;
        Debug.Log("Door locked? " + isLocked);
    }

    public void LockDoor() {
        isLocked = true;
        Debug.Log("Door locked? " + isLocked);
    }
}
