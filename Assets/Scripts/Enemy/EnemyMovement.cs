using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float enemySmoothRotation = 5f;
    // speed
    // movement
    // rotation
    public void MoveTowardsTarget(GameObject go, Transform targetTransform) {
        go.transform.position = Vector2.MoveTowards(go.transform.position, targetTransform.position, enemySpeed * Time.deltaTime);
    }
    public void RotateObject(Transform target) {
        Vector2 lookAtWaypoint = transform.InverseTransformPoint(target.position);
        float angle = Mathf.Atan2(lookAtWaypoint.y, lookAtWaypoint.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, angle * enemySmoothRotation * Time.deltaTime);
    }
}
