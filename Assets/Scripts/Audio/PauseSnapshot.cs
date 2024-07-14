using System;
using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class PauseSnapshot : Singleton<PauseSnapshot>
{
    private string pauseSnapshotPath = "snapshot:/Pause Effect";
    private EventInstance pauesSnapshotEvent;
    [SerializeField] private EventReference startPauseSfx;
    [SerializeField] private EventReference stopPauseSfx;
    private void Start()
    {
        pauesSnapshotEvent = FMODUnity.RuntimeManager.CreateInstance(pauseSnapshotPath);
        pauesSnapshotEvent.stop(STOP_MODE.ALLOWFADEOUT);

    }

    [ProButton]
    public void StartPauseAudio()
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(startPauseSfx);

        pauesSnapshotEvent.start();
    }
    [ProButton]
    public void StopPauseAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(stopPauseSfx);

        pauesSnapshotEvent.stop(STOP_MODE.ALLOWFADEOUT);

    }
}
