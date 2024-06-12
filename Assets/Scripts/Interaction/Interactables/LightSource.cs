using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LightSource : MonoBehaviour, IInteractable
{
    [SerializeField] private LaserBeamLogic laserBeamLogic;
    [SerializeField] private LightSourceVisual lightSourceVisual;
    public bool LightSourceIsOn {get; private set;}
    [HideInInspector] public UnityEvent OnLightSourceInteracted;
    private void Start() {  
        LightSourceIsOn = false;      
        if (laserBeamLogic == null)
            Debug.LogWarning("This obj doesnt have the LaserBeamLogic assigned in inspector ", gameObject);
    }
    public void Interact() {
        LightSourceIsOn = !LightSourceIsOn;
        laserBeamLogic.ToggleLaserBeam();
        lightSourceVisual.ToggleLight();
         OnLightSourceInteracted?.Invoke();
    }

//these arent even being used, why are they here 
    public void TurnOffLightSource()
    {
        //LightSourceIsOn = false;
        laserBeamLogic.DisableLaser();
        lightSourceVisual.DeactivateLight();
        //OnLightSourceInteracted?.Invoke();
    }

    public void TurnOnLightSource()
    {
        
        //LightSourceIsOn = true;
        laserBeamLogic.EnableLaser();
        lightSourceVisual.ActivateLight();
        //OnLightSourceInteracted?.Invoke();
    }
}
