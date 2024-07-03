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
    [SerializeField] private EventInstance pauesSnapshotEvent;

    private void Start()
    {
        pauesSnapshotEvent = FMODUnity.RuntimeManager.CreateInstance(pauseSnapshotPath);
    }

    [ProButton]
    public void StartPauseAudio()
    {
        pauesSnapshotEvent.start();
    }
    [ProButton]
    public void StopPauseAudio()
    {
        pauesSnapshotEvent.stop(STOP_MODE.ALLOWFADEOUT);

    }
}
