using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkyCode;

public class PortalVisual : DoorVFX
{
    [SerializeField] private Light2D portalLight;
    [SerializeField] private float lightDimnessWhenClosed = 0.4f;

    void Start() {
        PlayClose();
    }
    public override void PlayOpen() {
        particleSystem.Play();
        portalLight.color.a = 1f;
    }
    public override void PlayClose() {
        particleSystem.Stop();
        portalLight.color.a = lightDimnessWhenClosed;
    }
}
