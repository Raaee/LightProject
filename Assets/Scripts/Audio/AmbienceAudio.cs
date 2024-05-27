using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceAudio : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private FMODUnity.EventReference ambienceLoop;
    [SerializeField] private FMODUnity.EventReference ambienceRandomOneShots;

    private ExtendedAudioContainer ambiLoopAudioContainer = new ExtendedAudioContainer();
    private bool IsActive = false;
    private float timer = 0.0f;
    private float defaultTriggerTime = 8f;
    private float timeToTriggerOneShot;

    private void Start()
    {
        ambiLoopAudioContainer.InitAudio(ambienceLoop);
        timeToTriggerOneShot = defaultTriggerTime;
    }


    private void Update()
    {
        if (IsActive == false)
            return;

        timer += Time.deltaTime;

        if(timer >= timeToTriggerOneShot)
        {
            PlayRandomAmbienceTrigger();
            timer = 0;

            timeToTriggerOneShot = Random.Range(defaultTriggerTime - 1f, defaultTriggerTime + 1f);
        }
    }


    private void PlayRandomAmbienceTrigger()
    {
        FMODUnity.RuntimeManager.PlayOneShot(ambienceRandomOneShots, transform.position);
    }

    private void StartAmbienceAudioSystem()
    {
        //start container 
        ambiLoopAudioContainer.StartAudio();
        //set bool to unlock ambi oneshots
        IsActive = true;
    }

    private void StopAmbienceAudioSystem()
    {
        //stop container 
        ambiLoopAudioContainer.StopAudio();
        //stop bool
        IsActive = false;
    }

    private bool IsEventPlaying(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }
}
