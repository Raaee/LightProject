using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVisual : DoorVFX
{
    public override void PlayOpen() {
        particleSystem.Stop();
    }
    public override void PlayClose() {
        particleSystem.Play();
    }
}
