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

        Destroy(laserObject, 0.05f);
    }

    private void CastLaser(Vector3 pos, Vector3 dir) {
        laserIndices.Add(pos);

        Ray2D ray = new Ray2D(pos, dir);
        RaycastHit2D hit;

        if (Physics2D.Raycast(ray, out hit, 100, 1)) {
            CheckHit(hit, dir);
        }
        else {
            laserIndices.Add(ray.GetPoint(100));
            UpdateLaser();
        }
    }

    private void CheckHit(RaycastHit2D hit, Vector3 direction) {
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
