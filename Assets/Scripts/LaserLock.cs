using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLock : MonoBehaviour
{
    [SerializeField] private LaserKeys laserKey;
    [SerializeField] private LaserDetection laserDetection;
    [SerializeField] private LaserBeamLogic laserBeam;
    public bool lockStatus;


    private void Start()
    {
        lockStatus = true; //The lock will always be on statusLock. False is unlock
        laserDetection.OnUnlock.AddListener(Unlock);
        laserDetection.OnLock.AddListener(Lock);

    }

    public void Unlock() //This only send it unlock information to the DoorLogic
    {
        if (laserBeam.GetLaserKey().Equals(laserKey))
        {
            lockStatus = false;
        }
    }

    public void Lock()
    {
        lockStatus = true;
    }
}

