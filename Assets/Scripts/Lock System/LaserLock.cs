using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserLock : ILock
{
    [SerializeField] private LaserKeys laserKey;
    [SerializeField] private LaserDetection laserDetection;
    [SerializeField] private LaserBeamLogic laserBeam;
    private void Start()
    {
        laserDetection.OnLaserActive.AddListener(Unlock);
        laserDetection.OnLaserInactive.AddListener(Lock);
        Lock();
    }
    public override void Unlock() //This only send it unlock information to the DoorLogic
    {
        if (laserBeam.GetLaserKey().Equals(laserKey))
        {
            IsLocked = false;
        }
        OnInputDetection.Invoke();
    }
    public override void Lock()
    {
        IsLocked = true;
        OnInputDetection.Invoke();
    }
}

