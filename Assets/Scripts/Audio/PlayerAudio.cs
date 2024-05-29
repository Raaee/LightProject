using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private FMODUnity.EventReference playerWalkAudio;
    [SerializeField] private FMODUnity.EventReference playerPushAudio; //half flame, half pushing block
    [SerializeField] private FMODUnity.EventReference playerFlameIdle;
    [SerializeField] private FMODUnity.EventReference playerSpawnIn;
    [SerializeField] private FMODUnity.EventReference pickUpKeySfx;

    private ExtendedAudioContainer playerFlameAudioContainer = new ExtendedAudioContainer();
    private ExtendedAudioContainer playerPushAudioContainer = new ExtendedAudioContainer();
    [Header("References")]
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Walking Data")]
    private float minInterval = 0.25f;
    private float nextPlayTime;

    private void Start()
    {
        nextPlayTime = Time.time + minInterval; // Initialize last play time with offset to prevent immediate play
        playerPushAudioContainer.InitAudio(playerPushAudio);
        playerFlameAudioContainer.InitAudio(playerFlameIdle);
    }

    private void Update()
    {
        if (playerMovement.IsPlayerMoving() && (Time.time >= nextPlayTime))
        {
            PlayWalkAudio();
            nextPlayTime = Time.time + minInterval;
        }
    }

    private void PlayWalkAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(playerWalkAudio, transform.position);
    }

    private void PlaySpawnAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(playerSpawnIn, transform.position);
    }
    private void PlayKeyPickUpAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(pickUpKeySfx, transform.position);
    }


    //These methods can be removed, call the contianer directly 
    private void PlayPushAudio()
    {
        playerPushAudioContainer.StartAudio();
    }

    private void StopPushAudio()
    {
        playerPushAudioContainer.StopAudio();
    }

}
