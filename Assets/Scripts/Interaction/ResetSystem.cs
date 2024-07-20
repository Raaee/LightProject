using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResetSystem : MonoBehaviour, IInteractable
{
    public Dictionary<GameObject, Transform> ObjsInLevel = new Dictionary<GameObject, Transform>();
    private GameObject player;
    private GameObject playerSpawnPoint;
    private PlayerAnimations playerAnimations;
    private InteractVisual interactVisual;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        playerAnimations = player.GetComponentInChildren<PlayerAnimations>();
        interactVisual = transform.parent.GetComponentInChildren<InteractVisual>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pillar"))
        {
            ObjsInLevel.Add(obj, obj.transform);
        }

    }
    public void Interact() {
        ResetAll();
        ReturnPlayerToSpawnPoint();
        interactVisual.NormalSprite();
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
        player.transform.position = playerSpawnPoint.transform.position;
        playerAnimations.PlayParticleAnimation();
        Debug.LogWarning("Where is Play Particale Animatinos");
    }
}

