
using UnityEngine;
using UnityEngine.Events;
using FunkyCode;


public class FieldOfViewDetection : MonoBehaviour
{
    private Light2D fovLight;
     private Transform player;
    [SerializeField] private float fovAngle = 60f;
    [SerializeField] private float fovRange = 5f;
    private const float FOV_RANGE_MULTIPLIER = 1.5f;
    private Vector3 lookDirection = Vector3.forward;
    private bool playerJustGotDetected = false;
     public UnityEvent OnPlayerDetect { get; set; }
     public UnityEvent OnPlayerUnDetect { get; set; }

    private void Awake()
    {
        fovLight = GetComponent<Light2D>();
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        if (!player)
           Debug.LogError("No player in scene!");
    }

    void Start() {
        AdjustLightToAngle();
    }
    private void Update()
    {
        lookDirection = transform.rotation * Vector3.up;
        DetectPlayer();
    }
    
    private void DetectPlayer()
    {
        if (IsTargetInsideFOV(player))
        {
           
            if (!playerJustGotDetected)
            { Debug.Log("I see player");
                OnPlayerDetect?.Invoke();
                playerJustGotDetected = true;
            }
        }
        else
        {
            if (playerJustGotDetected)
            {
                Debug.Log("player not detected");
                OnPlayerUnDetect?.Invoke();
                playerJustGotDetected = false;
            }
        }
    }
    
    private bool IsTargetInsideFOV(Transform target) {

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
    
  
}
