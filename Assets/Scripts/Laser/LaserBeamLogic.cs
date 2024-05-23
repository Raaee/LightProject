using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class LaserBeamLogic : MonoBehaviour
{
    [SerializeField] private LayerMask detectingLayerMask;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform rotateObj;
    [field: SerializeField] public bool IsActive { get; set; }
    [SerializeField] private LaserKeys laserKey = LaserKeys.TRIANGLE_LASER;
    [SerializeField] private CardinalDirection laserBeamCardinalDirection = CardinalDirection.SOUTH;
    [field: SerializeField] public float LaserStrength { get; set; }
    private Quaternion rotation;

    private void Start()
    {
        LaserStrength = 7f;
        IsActive = false;
        Vector2 direction = Utility.GetUnitVector(laserBeamCardinalDirection);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        rotateObj.transform.rotation = rotation;
        DisableLaser();
    }

    private void Update()
    {
        if (!IsActive) {
            DisableLaser();
            return;
        }
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
