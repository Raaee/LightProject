using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBeam : MonoBehaviour
{
    private LineRenderer laserLineRenderer;
    //private List<Vector2> laserIndices = new List<Vector2>();
    private int reflections;
    private Vector2 pos;
    private Vector2 dir;
    [SerializeField] private float maxStrength = 100; 
    private float currentStrength;
    [SerializeField] private LaserDirection laserDirection = LaserDirection.NORTH;
    private Vector2 v2LaserDirection;
    Ray2D ray;


    private void Start()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        laserLineRenderer.enabled = true;
        Physics2D.queriesStartInColliders = false;
        //laserLineRenderer.useWorldSpace = fl;
        pos = transform.position;
        dir = Vector2.up;
        //var LightPhysicsInstase = new LightPhysic(new Vector2(0, 0), Vector2.up, 0.5f, 0.5f, Color.red, Color.red);
    }

    private void Update()
    {
        //var LightPhysicsInstase = new LightPhysic(new Vector2(0, 0), Vector2.up, 0.5f, 0.5f, Color.red, Color.red);
        CastLaser();
    }

    private void CastLaser()
    {
        //LineCast also works test!!!

        laserLineRenderer.positionCount = 1;
        laserLineRenderer.SetPosition(0, pos);

        RaycastHit2D hit = Physics2D.Raycast(pos, dir, maxStrength);
        //Ray2D ray = new Ray2D(pos, dir);
        currentStrength = maxStrength;
        Debug.Log(pos);
        Debug.Log(dir);
        Debug.DrawLine(pos, dir, Color.red);
        //laserHit.position = dir;
        /*laserLineRenderer.SetPosition(0, pos);
        laserLineRenderer.SetPosition(1, dir);*/
        for (int i = 0; i < reflections; i++) {
            laserLineRenderer.positionCount += 1;

            if (hit)
            {
                CheckHit(hit);
            }
            else {
                laserLineRenderer.SetPosition(laserLineRenderer.positionCount - 1, transform.position + transform.right * currentStrength);
                break;
            }
        }
    }

    private void CheckHit(RaycastHit2D hit)
    {
        if (hit.collider.tag.Equals("Mirror"))
        {
            pos = hit.collider.gameObject.transform.position;
            dir = v2LaserDirection * maxStrength;


            switch (laserDirection)
            {
                case LaserDirection.NORTH:
                case LaserDirection.NORTH_EAST:
                case LaserDirection.NORTH_WEST:
                    dir.y = pos.y + maxStrength; break;
                case LaserDirection.WEST:
                case LaserDirection.EAST:
                    dir.y = pos.y; break;
                case LaserDirection.SOUTH:
                case LaserDirection.SOUTH_EAST:
                case LaserDirection.SOUTH_WEST:
                    dir.y = pos.y - maxStrength; break;
            }

            laserLineRenderer.SetPosition(laserLineRenderer.positionCount - 1, dir);
            Debug.Log("Hit Mirror");
        }
    }

    private void SetLaserDirection(LaserDirection laserDirection) {
        switch (laserDirection)
        {
            case LaserDirection.NORTH:
                v2LaserDirection = new Vector2(0, 1); break;
            case LaserDirection.NORTH_EAST:
                v2LaserDirection = new Vector2(1, 1); break;
            case LaserDirection.NORTH_WEST:
                v2LaserDirection = new Vector2(-1, 1); break;
            case LaserDirection.EAST:
                v2LaserDirection = Vector2.right; break;
            case LaserDirection.SOUTH:
                v2LaserDirection = Vector2.down; break;
            case LaserDirection.SOUTH_EAST:
                v2LaserDirection = new Vector2(1, -1); break;
            case LaserDirection.SOUTH_WEST:
                v2LaserDirection = new Vector2(-1, -1); break;
            case LaserDirection.WEST:
                v2LaserDirection = Vector2.left; break;
        }
    }

    [ProButton]
    public void Test() {
        SetLaserDirection(laserDirection);
    }
}

public enum LaserDirection {
    NORTH,
    NORTH_EAST,
    NORTH_WEST,
    EAST,
    SOUTH,
    SOUTH_EAST,
    SOUTH_WEST,
    WEST
}