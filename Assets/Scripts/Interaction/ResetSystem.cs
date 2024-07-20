using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResetSystem : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public Dictionary<GameObject, Transform> ObjsInLevel = new Dictionary<GameObject, Transform>();
    [SerializeField] PlayerAnimations playerAnimations;
    private void Start()
    {
        PlayerAnimations playerAnimations = GetComponent<PlayerAnimations>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pillar"))
        {
            ObjsInLevel.Add(obj, obj.transform);
        }

    }
    public void Interact() {
        ResetAll();
        ReturnPlayerToSpawnPoint();
    }
    [ProButton]
    public void ResetAll()
    {
        ResetPillars();
        ResetLightSources();
    }

    [ProButton]
    public void TurnOnLights()
    {
        TurnOnLightSources();
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

    public void TurnOnLightSources()
    {
        foreach (KeyValuePair<GameObject, Transform> obj in ObjsInLevel)
        {
            obj.Key.transform.position = obj.Value.position;
            if (obj.Key.GetComponentInChildren<LightSource>() == null)
            {
                continue;
            }
            LightSource lightSource = obj.Key.GetComponentInChildren<LightSource>();
            lightSource.TurnOnLightSource();

        }
    }

    public void ReturnPlayerToSpawnPoint() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        playerAnimations = player.GetComponentInChildren<PlayerAnimations>();
        player.transform.position = spawnPoint.transform.position;
     //   playerAnimations.PlayParticleAnimation();
     Debug.LogWarning("Where is Play Particale Animatinos");
    }
}

