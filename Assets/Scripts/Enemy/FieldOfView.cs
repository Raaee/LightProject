using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FunkyCode;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private Light2D fovLight;
    [SerializeField] private Transform player;
    [SerializeField] private float fovAngle = 60f;
    [SerializeField] private float fovRange = 5f;
    private const float FOV_RANGE_MULTIPLIER = 1.5f;
    private Vector3 lookDirection = Vector3.forward;

    [HideInInspector] public UnityEvent OnPlayerDetect;
    [HideInInspector] public UnityEvent OnPlayerUnDetect;

    void Start() {
        AdjustLightToAngle();
    }
    private void Update() {
        lookDirection = transform.rotation * Vector3.up;
        //Debug.LogWarning(IsTargetInsideFOV(player));
        detectPlayer();
    }
    public bool IsTargetInsideFOV(Transform target) {

        Vector2 directionToTarget = (target.position - transform.position).normalized;
        float angleToTarget = Vector3.Angle(lookDirection, directionToTarget);
        
        if (angleToTarget < fovAngle / 2) {
            float distance = Vector3.Distance(target.position, transform.position);
            return distance < fovRange;
        }
        return false;
    }   
    public void AdjustLightToAngle() {
        fovLight.size = fovRange * FOV_RANGE_MULTIPLIER;
    }

    public void detectPlayer()
    {
        if (IsTargetInsideFOV(player)) {
            OnPlayerDetect.Invoke();
        }
        else
            unDetectPlayer();
    }

    public void unDetectPlayer()
    {
        OnPlayerUnDetect.Invoke();
    }
}
