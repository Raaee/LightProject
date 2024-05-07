using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamLogic : MonoBehaviour
{
   [field: SerializeField] public bool IsActive { get; set; }
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private CardinalDirection laserBeamCardinalDirection = CardinalDirection.EAST;
    private Quaternion rotation;
    [SerializeField]private LayerMask detectingLayerMask;

    private void Start()
    {
        IsActive = false;
        DisableLaser();
    }

    private void Update()
    {
     
        if (!IsActive) return;
        UpdateLaser();
    }

    

    private void UpdateLaser()
    {
        RotateObject();
        //invisible point far away is what we are setting the second point to
        float offsetDistance = 15f;
        Vector2 offsetPosition = Utility.GetOffsetPosition(transform.position, offsetDistance, laserBeamCardinalDirection);

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, offsetPosition);

        Vector2 direction = offsetPosition - (Vector2)transform.position;
        float calcDistance = Vector2.Distance(offsetPosition, transform.position); 
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, calcDistance, detectingLayerMask);

        if(hit)
        {
            /*
             LaserBeamLogic laserBeam = hit.collider.gameObject.GetComponent<LaserBeamLogic>();
             if (laserBeam == null)
             {
                 Debug.Log("laser was null");
                 return;
             }
             if (laserBeam == this) return;
             if(laserBeam.IsActive == false)
             {
                 laserBeam.DEBUG_ToggleLaserBeam();
             }
            */
            Debug.Log("doing a hit");

            LaserDetection laserDetect = hit.collider.gameObject.GetComponent<LaserDetection>();
            laserDetect?.DetectingTheLaser();

            lineRenderer.SetPosition(1, hit.point);
        }
    }

    [ProButton]
    public void DEBUG_ToggleLaserBeam()
    {
        IsActive = !IsActive;
        if (IsActive)
            EnableLaser();
        else
            DisableLaser();
    }

    
    private void RotateObject()
    {
        Vector2 direction = Utility.GetUnitVector(laserBeamCardinalDirection);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotation;
    }

    private void EnableLaser()
    {
        lineRenderer.enabled = true;
    }
    private void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
