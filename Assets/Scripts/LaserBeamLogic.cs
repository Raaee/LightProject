using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamLogic : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform firePoint;
    private Quaternion rotation;

    private void Start()
    {
        DisableLaser();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            EnableLaser();
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            UpdateLaser();
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            DisableLaser(); 
        }
    }

    private void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    private void UpdateLaser()
    {
        RotateToMouse();
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude);

        if(hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
    }

    void RotateToMouse()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0,0,angle);
        transform.rotation = rotation;
    }    

    private void EnableLaser()
    {
        lineRenderer.enabled = true;
    }
}
