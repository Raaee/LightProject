using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPhysic : MonoBehaviour
{
    public GameObject laserObject;
    private LineRenderer laser;
    private List<Vector3> laserIndices = new List<Vector3>();

    public LightPhysic(Vector3 pos, Vector3 dir, float startWidth, float endWigth, Color startColor, Color endColor) {
        laser = new LineRenderer();
        laserObject = new GameObject();
        laserObject.name = "Laser Beam";

        laser = this.laserObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
        laser.startWidth = startWidth;
        laser.endWidth = endWigth;
        laser.startColor = startColor;
        laser.endColor = endColor;
        //laser.material = materia;

        CastLaser(pos, dir);

        //Destroy(laserObject, 0.05f);
    }

    private void CastLaser(Vector2 pos, Vector2 dir) {
        RaycastHit2D hit = Physics2D.Raycast(pos, dir);
        Debug.DrawLine(transform.position, hit.point);

        //laserIndices.Add(pos);

        /*Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, 1)) {
            CheckHit(hit, dir);
        }
        else {
            laserIndices.Add(ray.GetPoint(100));
            UpdateLaser();
        }*/
    }

    private void CheckHit(RaycastHit hit, Vector2 direction) {
        if (hit.collider.tag.Equals("Mirror"))
        {
            Vector3 pos = hit.point;
            Vector3 dir = Vector3.Reflect(direction, hit.normal);

            CastLaser(pos, dir);
        }
        else {
            laserIndices.Add(hit.point);
            UpdateLaser();
        }
    }

    private void UpdateLaser() {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector3 index in laserIndices) {
            laser.SetPosition(count, index);
            count++;
        }
    }
}
