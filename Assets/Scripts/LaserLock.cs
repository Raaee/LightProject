using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserLock : ILock
{

    [SerializeField] private LaserKeys laserKey;
    [SerializeField] private LaserDetection laserDetection;
    [SerializeField] private LaserBeamLogic laserBeam;
    //public bool lockStatus;

    public UnityEvent OnlaserNotDetected;

    private void Start()
    {
        lockStatus = true; //The lock will always be on statusLock. False is unlock
        laserDetection.OnUnlock.AddListener(Unlock);
        laserDetection.OnLock.AddListener(Lock);

    }

    public override void Unlock() //This only send it unlock information to the DoorLogic
    {
        if (laserBeam.GetLaserKey().Equals(laserKey))
        {
            lockStatus = false;
        }
        OnlaserDetected.Invoke();
    }

    public override void Lock()
    {
        Debug.Log("locking");
        lockStatus = true;
        OnlaserDetected.Invoke();
    }
}

