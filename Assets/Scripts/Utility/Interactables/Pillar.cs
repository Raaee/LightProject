using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : IInteractable
{
    [SerializeField] private CardinalDirection cardinalDirection;
    [SerializeField] private LaserDetection laserDetection;
    [SerializeField] private LaserBeamLogic laserBeamLogic;

    private void Start() {
        laserDetection.OnLaserActive.AddListener(ReflectLaser);
        laserDetection.OnLaserInactive.AddListener(DisableLaser);
    }
    [ProButton]
    public override void Interact() {
        RotateDirection();
        Debug.Log("Rotating");
    }
    public void RotateDirection() {
        int index = (int)cardinalDirection;
        index++;
        if (index >= System.Enum.GetNames(typeof(CardinalDirection)).Length) {
            index = 0;
        }
        cardinalDirection = (CardinalDirection)index;
        laserBeamLogic.SetCardinalDirection(cardinalDirection);
    }
    public void ReflectLaser() {
        laserBeamLogic.EnableLaser();
    }
    public void DisableLaser() {
        laserBeamLogic.DisableLaser();
    }
}