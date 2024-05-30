using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkyCode;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float fovAngle = 60f;
    [SerializeField] private float fovRange = 5f;
    [SerializeField] private Vector3 lookDirection;
    [SerializeField] private Light2D fovLight;
    [SerializeField] private Transform player;

    public bool IsTargetInsideFOV(Transform target) {

        Vector2 directionToTarget = (target.position - transform.position).normalized;
        Debug.Log("dtt " + directionToTarget);
        float angleToTarget = Vector3.Angle(lookDirection, directionToTarget);
        
        if (angleToTarget < fovAngle / 2) {
            float distance = Vector3.Distance(target.position, transform.position);
            return distance < fovRange;
        }
        AdjustLightToAngle(fovAngle);
        return false;
    }
    private void Update() {
        lookDirection = Quaternion.Euler(0,fovAngle,0) * transform.forward;
        Debug.LogWarning(IsTargetInsideFOV(player));   
    }
    public void AdjustLightToAngle(float angleToTarget) {
        fovLight.freeFormPoints.points[0] = Vector2.zero;

        Vector2 firstPoint = new Vector2(-Utility.GetVectorFromAngle(angleToTarget).x, lookDirection.y);
        fovLight.freeFormPoints.points[1] = firstPoint * fovRange;

        Vector2 secondPoint = new Vector2(Utility.GetVectorFromAngle(angleToTarget).x, lookDirection.y);
        fovLight.freeFormPoints.points[2] = secondPoint * fovRange;
        Light2D.ForceUpdateAll();
    }
}
