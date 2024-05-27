using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResetSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<GameObject, Transform> ObjsInLevel = new Dictionary<GameObject, Transform>();
    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pillar"))
        {
            ObjsInLevel.Add(obj, obj.transform);
        }

    }
    [ProButton]
    public void ResetLevel()
    {
        ResetPillars();
        ResetLightSources();
    }

    public void ResetPillars()
    {
        foreach (KeyValuePair<GameObject, Transform> obj in ObjsInLevel)
        {
            Debug.Log("Pillar Reset");
            if (obj.Key.GetComponentInChildren<Pushable>()) {
                obj.Key.GetComponentInChildren<Pushable>().gameObject.transform.position = obj.Value.position;
            }
            obj.Key.transform.position = obj.Value.position;
            if(obj.Key.GetComponentInChildren<Pillar>() == null)
            {
               continue;
            }
            Pillar pillar = obj.Key.GetComponentInChildren<Pillar>();
            pillar.cardinalDirection = CardinalDirection.SOUTH_EAST;
            pillar.Interact();
            pillar.laserBeamLogic.DisableLaser();
        }
    }

    public void ResetLightSources()
    {
        foreach (KeyValuePair<GameObject, Transform> obj in ObjsInLevel)
        {
            obj.Key.transform.position = obj.Value.position;
            if (obj.Key.GetComponentInChildren<LightSource>() == null)
            {
                continue;
            }
            LightSource lightSource = obj.Key.GetComponentInChildren<LightSource>();
            lightSource.TurnOffLightSource();

        }
    }
}

