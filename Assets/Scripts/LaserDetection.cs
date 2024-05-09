using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserDetection : MonoBehaviour
{
    private bool isActivated = false;
    [SerializeField] float timer = 0f;
    float unDetectedTime = 0.25f;

    //Debugging
    public LaserBeamLogic laserBeam;
    public UnityEvent OnLaserActive;
    public UnityEvent OnLaserInactive;
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        if(!GetComponent<Collider2D>())
        { 
            Debug.LogError("This obj should have a Collider2D");
        }
    }
    public void OnLaserDetected() 
    {
        if (isActivated == false)
        {
            OnLaserStartActivated();
            isActivated = true;
        }
        else
        {
            Debug.Log("currently activated :) i am seen");
            timer = 0;                                            
        }
    }

    private void Update()
    {
        if(isActivated)
            timer += Time.deltaTime;
        
        if(timer > unDetectedTime)
        {
            //time has passed since detection, we are not detected anymore 
            if(isActivated == true)
            {
                OnLaserDeactivated();
                isActivated = false;
                timer = 0f;
            }
          
        }
    }
 
    private void OnLaserDeactivated()
    {
        Debug.Log("Laser deactivated");
        // laserBeam?.DisableLaser();
        OnLaserInactive.Invoke();
    }
    private void OnLaserStartActivated()
    { 
        Debug.Log("Laser activated");
        // laserBeam?.EnableLaser();
        OnLaserActive.Invoke();
    }
}
