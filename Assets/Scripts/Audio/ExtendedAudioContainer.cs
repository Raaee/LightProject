using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedAudioContainer
{
    private FMODUnity.EventReference audioReference;
    private FMOD.Studio.EventInstance audioInstance;

    public void InitAudio(FMODUnity.EventReference newAudioReference)
    {
        audioReference = newAudioReference;
        audioInstance = FMODUnity.RuntimeManager.CreateInstance(audioReference);
    }

    public void ConnectTo3DAudio(Transform instanceTransform, Rigidbody2D instanceRB2d)
    {
        RuntimeManager.AttachInstanceToGameObject(audioInstance, instanceTransform, instanceRB2d);
    }


    public void StartAudio()
    {
        audioInstance.start();
    }

    public void StopAudio(bool stopWithFadeOut = true)
    {
        if(stopWithFadeOut)
        {
            audioInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        else
        {
            audioInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}
