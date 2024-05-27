using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceAudio : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private FMODUnity.EventReference turnOnLightSource;
    [SerializeField] private FMODUnity.EventReference turnOffLightSource;
    [SerializeField] private FMODUnity.EventReference rotateLightSource;
    [SerializeField] private FMODUnity.EventReference idleLightSource;


    [Header("References")]
    [SerializeField] private Rigidbody2D lightSourceRb2d;
    [SerializeField] private Transform lightSourceTransform;


    private ExtendedAudioContainer idleLightSourceAudioContainer = new ExtendedAudioContainer();

    private void Start()
    {
        if(lightSourceRb2d == null || lightSourceTransform == null)
        {
            Debug.LogError("Make sure to set the rigidbody or transform inside the inspector ", this.gameObject);
        }
        idleLightSourceAudioContainer.InitAudio(idleLightSource);
        idleLightSourceAudioContainer.ConnectTo3DAudio(lightSourceTransform, lightSourceRb2d);
    }

    private void PlayTurnOnLSAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(turnOnLightSource, transform.position);
    }

    private void PlayTurnOffLSAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(turnOffLightSource, transform.position);
    }

    private void PlayRotateLSAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(rotateLightSource, transform.position);
    }

   

}
