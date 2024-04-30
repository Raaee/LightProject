using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBeam : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public  Transform laserHit;
    private Vector2 pos;
    private Vector2 dir;
    [SerializeField] private int maxStrength = 10;
    private int currentStrength;
    [SerializeField] private LaserDirection laserDirection = LaserDirection.NORTH;
    private Vector2 v2LaserDirection;


    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
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
        RaycastHit2D hit = Physics2D.Raycast(pos, dir);
        Debug.DrawLine(pos, dir, Color.red);
        laserHit.position = hit.point;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHit.position);
        if (hit) {
            CheckHit(hit);
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
            Debug.Log(dir.y);
            Debug.Log(dir);
            Debug.Log("Hit Mirror");
        }
    }

    public void SetLaserDirection(LaserDirection laserDirection) {
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