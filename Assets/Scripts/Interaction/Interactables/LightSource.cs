using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour, IInteractable
{
    [SerializeField] private LaserBeamLogic laserBeamLogic;
    private void Start()
    {
        if (laserBeamLogic == null)
            Debug.LogWarning("This obj doesnt have the LaserBeamLogic assigned in inspector ", gameObject);
    }

    public void Interact() {
        laserBeamLogic.ToggleLaserBeam();   
    }
}
