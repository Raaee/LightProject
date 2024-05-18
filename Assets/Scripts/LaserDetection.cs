using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserDetection : MonoBehaviour
{
    private bool isActivated = false;
    [SerializeField] private float timer = 0f;
    float unDetectedTime = 0.25f;

    
    [HideInInspector] public UnityEvent OnLaserActive;
    [HideInInspector] public UnityEvent OnLaserInactive;
    private LaserKeys laserType = LaserKeys.NONE;


    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        if(!GetComponent<Collider2D>())
        { 
            Debug.LogError("This obj should have a Collider2D");
        }
    }
    public void OnLaserDetected(LaserKeys laserType) 
    {
        if (isActivated == false)
        {
            OnLaserStartActivated();
            isActivated = true;
        }
        else
        {          
            timer = 0;                                            
        }
        this.laserType = laserType;
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
        OnLaserInactive.Invoke();     
    }
    private void OnLaserStartActivated()
    { 
        OnLaserActive.Invoke();     
    }
}
