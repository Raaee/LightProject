using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class LaserBeamLogic : MonoBehaviour
{
    [SerializeField] private LayerMask detectingLayerMask;
    [SerializeField] private LayerMask lightBlockingLayerMask;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform rotateObj;
    [SerializeField] private LaserBeamVisual visual;

    [Header(" ")]
    [SerializeField] private LaserKeys laserKey = LaserKeys.TRIANGLE_LASER;
    [SerializeField] private CardinalDirection laserBeamCardinalDirection = CardinalDirection.SOUTH;
    
    [field: Tooltip("Length of the laser. This is initialized on Start")]
    [field: SerializeField] public float LaserStrength { get; set; }
    [field: SerializeField] public bool IsActive { get; set; }
    private Quaternion rotation;

    private void Start()
    {
        LaserStrength = 7f;
        IsActive = false;
        rotateObj.transform.rotation = Utility.GetRotationFromDirection(laserBeamCardinalDirection);
        visual.RotateLight(laserBeamCardinalDirection);
        DisableLaser();
    }

    private void Update()
    {
        if (!IsActive) {
            visual.DeactivateLight();
            DisableLaser();
            return;
        }
        visual.ActivateLight();
        UpdateLaser();
    }   

    private void UpdateLaser()
    {
        RotateObject();
        // laserStrength would be an invisible point far away is what we are setting the second point to        
        Vector2 offsetPosition = Utility.GetOffsetPosition(transform.position, LaserStrength, laserBeamCardinalDirection);

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, offsetPosition);

        Vector2 direction = offsetPosition - (Vector2)transform.position;
        float calcDistance = Vector2.Distance(offsetPosition, transform.position); 
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, calcDistance, detectingLayerMask);
        RaycastHit2D hitLightBlocker = Physics2D.Raycast((Vector2)transform.position, direction.normalized, calcDistance, lightBlockingLayerMask);

        if (hitLightBlocker) {
            lineRenderer.SetPosition(1, hitLightBlocker.point);
            return;
        }
        if(hit)
        {    
            LaserDetection laserDetect = hit.collider.gameObject.GetComponent<LaserDetection>();
            LaserBeamLogic beam = hit.collider.gameObject.GetComponentInChildren<LaserBeamLogic>();
            laserDetect?.OnLaserDetected(laserKey);
            laserKey = laserDetect.GetLaserType();
            if (beam) beam.laserKey = laserKey;
            lineRenderer.SetPosition(1, hit.point);
        }
    }

    [ProButton]
    public void ToggleLaserBeam()
    {
        IsActive = !IsActive;
        if (IsActive)
            EnableLaser();
        else
            DisableLaser();
    }

    public LaserKeys GetLaserType() {
        return laserKey;
    }

    public void SetCardinalDirection(CardinalDirection dir) {
        laserBeamCardinalDirection = dir;
    }
    private void RotateObject()
    {
        Vector2 direction = Utility.GetUnitVector(laserBeamCardinalDirection);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        rotateObj.transform.rotation = rotation;
        visual.RotateLight(laserBeamCardinalDirection);
    }

    public void EnableLaser()
    {
        lineRenderer.enabled = true;
        IsActive = true;
    }
    public void DisableLaser()
    {
        lineRenderer.enabled = false;
        IsActive = false;
    }
}
