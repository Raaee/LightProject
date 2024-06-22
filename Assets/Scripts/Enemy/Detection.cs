using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detection : MonoBehaviour
{
    [SerializeField] private EnemyVisuals enemyVisuals;
    [SerializeField] private EnemyPatrol enemyPatrol;
    [SerializeField] private float detectionTimeToLoseGame = 2f;

    private FieldOfViewDetection fieldOfViewDetection;
    private float detectionTimer = 0f;
    private bool playerDetected = false;
    private bool fullPlayerDetectionCompletedGameOver = false;

    public UnityEvent OnDetectedGameOver;

    void Awake() { 
        fieldOfViewDetection = GetComponent<FieldOfViewDetection>();
    }

    private void Start() {
        ResetDetectionStatus();
        fieldOfViewDetection.OnPlayerDetect.AddListener(FOV_OnPlayerDetected);
        fieldOfViewDetection.OnPlayerUnDetect.AddListener(FOV_OnPlayerUnDetected);
    }
    private void Update() {
        if (fullPlayerDetectionCompletedGameOver) return;
        CheckDetectionTime();
    }

    //TODO: refactor to FOV Detection script
    //TODO: make the lose event only happen once
    private void CheckDetectionTime() {
        if (!playerDetected) {
            detectionTimer = 0;
            return;
        }

        detectionTimer += Time.deltaTime;
        if (detectionTimer > detectionTimeToLoseGame) {
            Debug.Log("Player got caught by enemy. gameover bruv");
            fullPlayerDetectionCompletedGameOver = true;
            enemyVisuals.PlayDetect();
            StartCoroutine(StartDeathCountDown());
        }
    }
    public IEnumerator StartDeathCountDown() {
        yield return new WaitForSeconds(detectionTimeToLoseGame / 2);
        enemyVisuals.DisableLight();
        yield return new WaitForSeconds(detectionTimeToLoseGame);
        OnDetectedGameOver.Invoke();
    }
    public void FOV_OnPlayerDetected() {
        Debug.Log("got it");
        playerDetected = true;
        enemyPatrol.stopMovement = true;
    }

    public void FOV_OnPlayerUnDetected() {
        Debug.Log("dropped it");
        playerDetected = false;
        enemyPatrol.stopMovement = false;
    }
    public void ResetDetectionStatus() {
        fullPlayerDetectionCompletedGameOver = false;
        playerDetected = false;
    }
}
