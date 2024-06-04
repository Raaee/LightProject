using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private GameObject objectToMove;
    public List<Transform> waypointList;
    private int currentWapointIndex = 0;
    [SerializeField] private bool randomPatrol = false;
    [SerializeField] private float waitTime = 1f;
    private float waitcounter = 0f;
    private bool waiting = false;

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
        movement.RotateObject(wp);
        if (Vector2.Distance(transform.position, wp.position) < 0.01f) {
            //objectToMove.transform.position = wp.position;
            waitcounter = 0f;
            waiting = true;
            if (randomPatrol) 
                currentWapointIndex = RandomIndex(currentWapointIndex);
            else
                currentWapointIndex = (currentWapointIndex + 1) % waypointList.Count;
        }
        else
        {
            movement.MoveTowardsTarget(objectToMove, wp);
        }
    }
    public int RandomIndex(int currentIndex) {
        int ranIndex;
        do {
            ranIndex = Random.Range(0, waypointList.Count);
        } while (ranIndex == currentIndex);
        return ranIndex;
    }

}
