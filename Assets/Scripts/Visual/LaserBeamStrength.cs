using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamStrength : MonoBehaviour
{
    [field: SerializeField] public float LaserStrength { get; set; }
    private float currentStrength;

    void Start() {

    }
}
