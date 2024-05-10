using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private LaserLock laserLockRed;
    [SerializeField] private LaserLock laserLockBlue;

    private void Update()
    {
        if (!laserLockRed.lockStatus && !laserLockBlue.lockStatus)
        {
            Debug.Log("Door Open");
        }
        else
        {
            Debug.Log("Door Close");
        }
    }
    // In DoorLogic it can cheack the lock status of multiple lock[red, blue, yellow, green] 
}
