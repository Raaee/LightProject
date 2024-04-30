using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBeam : MonoBehaviour
{
    private void Start()
    {
        var LightPhysicsInstase = new LightPhysic(new Vector3(0, 0, 0), Vector3.up, 1f, 1f, Color.red, Color.red);
    }

    private void Update()
    {
        var LightPhysicsInstase = new LightPhysic(new Vector3(0, 0, 0), Vector3.up, 1f, 1f, Color.red, Color.red);
    }

    //[ProButton]
    public void Test() {
        Debug.Log("Hello");
    }
}
