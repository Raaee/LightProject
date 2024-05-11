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
        foreach (ILock alock in locks)
        {
            alock.lockStatus = true;
            alock.OnlaserDetected.AddListener(CheckLockStatus);
        }
    }

    // In DoorLogic it can cheack the lock status of multiple lock[red, blue, yellow, green] 
    public void CheckLockStatus() {
        foreach (ILock alock in locks)
        {
            if (alock.lockStatus) {
                Debug.Log("Door Lock");
                LockDoor();
                return;
            }
        }
        UnlockDoor();
    }

    public void UnlockDoor() {
        isLocked = false;
        Debug.Log("Door Unlock");
    }

    public void LockDoor() {
        isLocked = true;
    }
}
