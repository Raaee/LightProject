using FMOD.Studio;
using FMODUnity;

using UnityEngine;


public class AmbienceAudio : MonoBehaviour
{
    [Header("AUDIO")] [SerializeField] private EventReference ambienceLoop;

    [SerializeField] private EventReference ambienceRandomOneShots;

    private readonly ExtendedAudioContainer ambiLoopAudioContainer = new();
    private readonly float defaultTriggerTime = 12f;
    private bool IsActive;
    private float timer;
    private float timeToTriggerOneShot;

    private void Start()
    {
        ambiLoopAudioContainer.InitAudio(ambienceLoop);
        timeToTriggerOneShot = defaultTriggerTime;

        StartAmbienceAudioSystem();

        var portal = FindObjectOfType<Portal>();
        if (portal == null)
        {
            Debug.LogError("No portal in scene?");
            return;
        }
        portal.OnPlayerEntersPortal.AddListener(StopAmbienceAudioSystem);
    }


    private void Update()
    {
        if (IsActive == false)
            return;

        timer += Time.deltaTime;

        if (timer >= timeToTriggerOneShot)
        {
            PlayRandomAmbienceTrigger();
            timer = 0;

            timeToTriggerOneShot = Random.Range(defaultTriggerTime - 1f, defaultTriggerTime + 1f);
        }
    }


    private void PlayRandomAmbienceTrigger()
    {
        RuntimeManager.PlayOneShot(ambienceRandomOneShots, transform.position);
    }

    private void StartAmbienceAudioSystem()
    {
        //start container 
        ambiLoopAudioContainer.StartAudio();
        //set bool to unlock ambi oneshots
        IsActive = true;
    }

    public void StopAmbienceAudioSystem()
    {
        //stop container 
        ambiLoopAudioContainer.StopAudio();
        //stop bool
        IsActive = false;
    }

    private bool IsEventPlaying(EventInstance instance)
    {
        PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != PLAYBACK_STATE.STOPPED;
    }
}