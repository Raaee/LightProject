using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour, IInteractable
{
    [SerializeField] private CardinalDirection cardinalDirection;
    [SerializeField] private LaserDetection laserDetection;
    [SerializeField] private LaserBeamLogic laserBeamLogic;
    [SerializeField] private PillarVisual visual;

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
        visual.ChangeSpriteRotation(cardinalDirIndex);
    }
    public void ReflectLaser() {
        laserBeamLogic.EnableLaser();
    }
    public void DisableLaser() {
        laserBeamLogic.DisableLaser();
    }
}
