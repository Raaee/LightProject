using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVisual : DoorVFX
{
    public override void PlayOpen() {
        doorVfxParticleSystem.Stop();
    }
    public override void PlayClose() {
        doorVfxParticleSystem.Play();
    }
}
