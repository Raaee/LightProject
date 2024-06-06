using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAudio : MonoBehaviour
{
    [SerializeField] private Pillar pillar;
    [SerializeField] private FMODUnity.EventReference rotateLightSource;

    private void Start()
    {
        pillar.OnPillarRotate.AddListener(PlayRotatePillarAudio);
    }
    private void PlayRotatePillarAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(rotateLightSource, transform.position);
    }
}
