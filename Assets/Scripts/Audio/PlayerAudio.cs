using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private FMODUnity.EventReference playerWalkAudio;
    [SerializeField] private FMODUnity.EventReference playerFlameIdle;
    [SerializeField] private FMODUnity.EventReference playerSpawnIn;
    [SerializeField] private FMODUnity.EventReference pickUpKeySfx;

    private ExtendedAudioContainer playerFlameAudioContainer = new ExtendedAudioContainer();
  
    [Header("References")]
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Rigidbody2D playerRb2d;
    [SerializeField] private Transform playerTransform;
    [Header("Walking Data")]
    private float minInterval = 0.25f;
    private float nextPlayTime;

    private const string PLAYER_WALK_PARAM = "IsWalking";

    private void Start()
    {
        Inventory.instance.OnItemPickedUp.AddListener(PlayKeyPickUpAudio);
        nextPlayTime = Time.time + minInterval; // Initialize last play time with offset to prevent immediate play
        playerFlameAudioContainer.InitAudio(playerFlameIdle);
        PlaySpawnAudio();
        playerFlameAudioContainer.ConnectTo3DAudio(playerTransform,playerRb2d );
        playerFlameAudioContainer.StartAudio();
        playerMovement.OnPlayerMove.AddListener(PlayerWalkingAudio);
        playerMovement.OnPlayerStop.AddListener(PlayerIdleAudio);
    }

    private void Update()
    {
        if (playerMovement.IsPlayerMoving() && (Time.time >= nextPlayTime))
        {
            //PlayWalkAudio();
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

    private void PlayerWalkingAudio()
    {
        playerFlameAudioContainer.SetParameter(PLAYER_WALK_PARAM, 1);
    }
    
    private void PlayerIdleAudio()
    {
        playerFlameAudioContainer.SetParameter(PLAYER_WALK_PARAM, 0);
    }

}
