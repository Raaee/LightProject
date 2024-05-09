using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : IInteractable
{
    [SerializeField] private LaserBeamLogic laserBeamLogic;
    private bool isOn = false;
    public override void Interact() {
        laserBeamLogic.ToggleLaserBeam();
        isOn = !isOn;
        Debug.LogWarning("Light Source On: " + isOn);
    }
}
