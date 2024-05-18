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
        if (laserBeam.GetLaserType() == LaserKeys.NONE || laserKey == LaserKeys.NONE)
        {
            Debug.LogError("The incoming laserbeam type or the LaserLock type hasnt been set in the inspector ", this.gameObject);
            return;
        }

        if (laserBeam.GetLaserType().Equals(laserKey))
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

