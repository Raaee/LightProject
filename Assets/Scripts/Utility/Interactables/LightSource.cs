using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : Interactable
{
    private bool isOn = false;
    protected override void Interact() {
        laserBeamLogic.ToggleLaserBeam();
        isOn = !isOn;
        Debug.LogWarning("Light Source On: " + isOn);
    }
}
