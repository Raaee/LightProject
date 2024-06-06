using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pillar : MonoBehaviour, IInteractable
{
    [field: SerializeField] public CardinalDirection cardinalDirection { get; set; }
    [SerializeField] private LaserDetection laserDetection;
    [field: SerializeField] public LaserBeamLogic laserBeamLogic { get; private set; }
    [SerializeField] private PillarVisual visual;
    public UnityEvent OnPillarRotate;

    private void Start() {
        laserDetection.OnLaserActive.AddListener(ReflectLaser);
        laserDetection.OnLaserInactive.AddListener(DisableLaser);
        cardinalDirection = CardinalDirection.SOUTH;
        laserBeamLogic.SetCardinalDirection(cardinalDirection);
    }
    [ProButton]
    public void Interact() {
        RotateDirection();
    }
    public void RotateDirection() {
        int cardinalDirIndex = (int)cardinalDirection;
        cardinalDirIndex++;
        if (cardinalDirIndex >= System.Enum.GetNames(typeof(CardinalDirection)).Length) {
            cardinalDirIndex = 0;
        }
        cardinalDirection = (CardinalDirection)cardinalDirIndex;
        laserBeamLogic.SetCardinalDirection(cardinalDirection);
        visual.ChangeSpriteRotation(cardinalDirIndex); //TODO: Remove this to go to the unity event 
        OnPillarRotate?.Invoke();
    }
    public void ReflectLaser() {
        laserBeamLogic.EnableLaser();
    }
    public void DisableLaser() {
        laserBeamLogic.DisableLaser();
    }
}
