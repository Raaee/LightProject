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
    [SerializeField] private LayerMask detectingLayerMask;
    [SerializeField] private LaserKeys laserKey = LaserKeys.TRIANGLE_LASER;

    private void Start()
    {
        IsActive = false;
        DisableLaser();
    }

    private void Update()
    {
        if (!IsActive) {
            DisableLaser();
            return;
        }
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
            LaserDetection laserDetect = hit.collider.gameObject.GetComponent<LaserDetection>();
            laserDetect?.OnLaserDetected(laserKey);
            lineRenderer.SetPosition(1, hit.point);
        }
    }

    [ProButton]
    public void ToggleLaserBeam()
    {
        IsActive = !IsActive;
        if (IsActive)
            EnableLaser();
        else
            DisableLaser();
    }

    public LaserKeys GetLaserType() {
        return laserKey;
    }

    public void SetCardinalDirection(CardinalDirection dir) {
        laserBeamCardinalDirection = dir;
    }
    private void RotateObject()
    {
        Vector2 direction = Utility.GetUnitVector(laserBeamCardinalDirection);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotation;
    }

    public void EnableLaser()
    {
        lineRenderer.enabled = true;
        IsActive = true;
    }
    public void DisableLaser()
    {
        lineRenderer.enabled = false;
        IsActive = false;
    }
}
