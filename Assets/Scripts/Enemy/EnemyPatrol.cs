using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public List<Transform> waypointList;
    private int currentWapointIndex;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private float enemySmoothRotation = 5f;
    private float waitcounter = 0f;
    private bool waiting= false;


    private void Update()
    {
        if (waiting)
        {
            waitcounter += Time.deltaTime;
            if (waitcounter < waitTime)
                return;
            waiting = false;
        }

        Transform wp = waypointList[currentWapointIndex];
        if (Vector2.Distance(transform.position, wp.position) < 0.01f) {
            transform.position = wp.position;
            waitcounter = 0f;
            waiting = true;
            rotateOnject(transform.position);
            currentWapointIndex = (currentWapointIndex + 1) % waypointList.Count;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wp.position, enemySpeed * Time.deltaTime);
            rotateOnject(wp.position);
        }
    }

    private void rotateOnject(Vector3 position) {
        Vector2 lookAtWaypoint = transform.InverseTransformPoint(position);
        float Angle = Mathf.Atan2(lookAtWaypoint.y, lookAtWaypoint.x) * Mathf.Rad2Deg - 90;

        transform.Rotate(0, 0, Angle);
    }
}
