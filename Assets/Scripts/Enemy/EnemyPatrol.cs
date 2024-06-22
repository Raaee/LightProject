using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private EnemyVisuals enemyVisuals;
    private EnemyMovement enemyMovement;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private bool randomPatrol = false;
    public List<Transform> waypointList;

    private int currentWaypointIndex = 0;
    private float waitTimer = 0f;
    private bool waiting = false;
    private bool isMoving = false;
    public bool stopMovement { get; set; }

    private void Awake() {
        enemyMovement = GetComponent<EnemyMovement>();
    }
    void Start() {
        stopMovement = false;
        isMoving = false;
    }

    private void Update()
    {
        enemyVisuals.Moving(isMoving);
        if (stopMovement) {
            isMoving = false;
            return;
        }

        if (waiting)
        {
            isMoving = false;
            waitTimer += Time.deltaTime;
            if (waitTimer < waitTime)
                return;
            waiting = false;
        }
        Transform currentWaypoint = waypointList[currentWaypointIndex];
        enemyMovement.RotateTowardsObject(currentWaypoint);

        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.01f) {
            waitTimer = 0f;
            waiting = true;
            if (randomPatrol)
                currentWaypointIndex = RandomIndex(currentWaypointIndex);
            else
                currentWaypointIndex = (currentWaypointIndex + 1) % waypointList.Count;
        }
        else
        {
            enemyMovement.MoveTowardsTarget(currentWaypoint);
            isMoving = true;
        }
    }

    private int RandomIndex(int currentIndex) {
        int ranIndex;
        do {
            ranIndex = Random.Range(0, waypointList.Count);
        } while (ranIndex == currentIndex);
        return ranIndex;
    }   
}
