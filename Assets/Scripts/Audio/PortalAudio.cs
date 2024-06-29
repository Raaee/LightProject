using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAudio : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private FMODUnity.EventReference startPortalSfx;
    [SerializeField] private FMODUnity.EventReference stopPortalSfx;
    [SerializeField] private DoorLogic portal;

    private ExtendedAudioContainer portalAC = new ExtendedAudioContainer();
    private void Start()
    {
        portalAC.InitAudio(startPortalSfx);
        portalAC.ConnectTo3DAudio(this.transform, GetComponent<Rigidbody2D>());
        portal.OnDoorLocked.AddListener(StopPortalAudio);
        portal.OnDoorUnLocked.AddListener(StartPortalAudio);
    }

    public void StartPortalAudio()
    {
        portalAC.StartAudio();
    }
    
    public void StopPortalAudio()
    {
        if(portal.GetIsDoorLockedFromOpen() == false)
            return;
        portalAC.StopAudio();
        FMODUnity.RuntimeManager.PlayOneShot(stopPortalSfx, transform.position);
    }
}
