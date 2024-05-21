using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGradient : MonoBehaviour
{
    [SerializeField] private LaserBeamLogic laserBeamLogic;
    private LineRenderer lr;
    private Color currentLineColor;

    void Start() {
        lr = GetComponent<LineRenderer>();

        // Obtain a number from 0 to 1, based on the current line's length
        float lineColorLength = laserBeamLogic.LaserStrength;

        // Now set the line's color based on that 0-1 number (0 = red, 1 = green)
        currentLineColor = Color.Lerp(Color.red, Color.green, lineColorLength);
    }


}
