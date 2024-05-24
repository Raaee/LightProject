using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkyCode;

public abstract class LightVisual : MonoBehaviour
{
    [SerializeField] protected GameObject sourceLight;
    protected bool isActive;
    private void Start() {
        sourceLight.GetComponent<Light2D>().applyRotation = Light2D.Rotation.Local;
        DeactivateLight();
    }
    public void ActivateLight() {
        isActive = true;
        sourceLight.SetActive(true);
    }
    public void DeactivateLight() {
        isActive = false;
        sourceLight.SetActive(false);
    }
    public void ToggleLight() {
        isActive = !isActive;
        if (isActive)
            ActivateLight();
        else
            DeactivateLight();
    }
}
