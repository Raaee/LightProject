using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamVisual : LightVisual
{
    public void RotateLight(CardinalDirection dir) {
        sourceLight.transform.rotation = Utility.GetRotationFromDirection(dir);
    }
}
