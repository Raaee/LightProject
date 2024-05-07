using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetection : MonoBehaviour
{
    private void Start()
    {
        if(!GetComponent<Collider2D>())
        { 
            Debug.Log("ay yo this obj should have a collider2d");
        }
    }
    public void DetectingTheLaser()
    {
        Debug.Log("I am seen :)");
    }    
}
