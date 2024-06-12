using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyPatrol : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private FieldOfViewDetection fieldOfViewDetection;
    public List<Transform> waypointList;
    private int currentWaypointIndex = 0;
    [SerializeField] private bool randomPatrol = false;
    [SerializeField] private float waitTime = 1f;
    private float waitTimer = 0f;
    private bool waiting = false;
    private bool playerDetected = false;

    private float detectionTimeToLoseGame = 1.5f; 
    private float detectionTimer = 0f;
    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        fieldOfViewDetection = GetComponent<FieldOfViewDetection>();
    }

    private void Start()
    {
        
        fieldOfViewDetection.OnPlayerDetect.AddListener(FOV_OnPlayerDetected);
        fieldOfViewDetection.OnPlayerUnDetect.AddListener(FOV_OnPlayerUnDetected);
    }

    private void Update()
    {
        CheckDetectionTime();
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer < waitTime)
                return;
            waiting = false;
        }
        Transform currentWaypoint = waypointList[currentWaypointIndex];
        enemyMovement.RotateTowardsObject(currentWaypoint);
        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.01f) {
            //objectToMove.transform.position = wp.position;
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
        }
    }
    //TODO: refactor to FOV Detection script
    //TODO: make the lose event only happen once
    private void CheckDetectionTime() 
    {
        if (!playerDetected)
        {
            detectionTimer = 0;
            return;
        }
        
       detectionTimer += Time.deltaTime;
       if (detectionTimer > detectionTimeToLoseGame)
       {
           Debug.Log("Player got caught by enemy. gameover bruv");
       }
    }

    private int RandomIndex(int currentIndex) {
        int ranIndex;
        do {
            ranIndex = Random.Range(0, waypointList.Count);
        } while (ranIndex == currentIndex);
        return ranIndex;
    }


    public void FOV_OnPlayerDetected()
    {
        Debug.Log("got it");
        playerDetected = true;
    }


    public void FOV_OnPlayerUnDetected()
    {
        Debug.Log("dropped it");
        playerDetected = false;
    }

   
}
