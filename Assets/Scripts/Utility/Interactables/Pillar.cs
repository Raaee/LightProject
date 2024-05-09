using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : Interactable
{
    [SerializeField] private LaserDirection laserDirection;
    [SerializeField] private LaserBeam laserBeam;

    protected override void Interact() {
        RotateDirection();
    }
    public void RotateDirection() {
        int index = (int)laserDirection;
        index++;
        if (index >= System.Enum.GetNames(typeof(LaserDirection)).Length) {
            index = 0;
        }
        laserDirection = (LaserDirection)index;
      //  laserBeam.SetLaserDirection(laserDirection);
    }
}
public enum LaserDirection {
    NORTH,
    NORTH_EAST,
    EAST,
    SOUTH_EAST,
    SOUTH,
    SOUTH_WEST,
    WEST,
    NORTH_WEST
}
