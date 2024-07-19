using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem spawnPS;
    [SerializeField] private PlayerMovement playerMovement;
    public bool IsWalkingState { get; set; }
    private const string IS_MOVING_ANIM_TAG = "isMoving";

    [HideInInspector] public UnityEvent OnSpawnAnimationEnd;
    private void Start()
    {
        spawnPS.Play();
        StopGlitch();
        //StartCoroutine(SpawnAnimation());
        IsWalkingState = false;
        animator.SetBool(IS_MOVING_ANIM_TAG, IsWalkingState);
        playerMovement.OnPlayerMove.AddListener(BeginToMove);
        playerMovement.OnPlayerStop.AddListener(StopMoving);
        OnSpawnAnimationEnd?.Invoke();
    }
    public void StopGlitch() {
        sr.material.SetFloat("_GlitchAmount", 0);
        sr.material.SetFloat("_WaveAmount", 0);
        sr.material.SetFloat("_WaveSpeed", 0);
    }
    public void PlayGlitch() {
        sr.material.SetFloat("_GlitchAmount", 10);
        sr.material.SetFloat("_WaveAmount", 7);
        sr.material.SetFloat("_WaveSpeed", 10);
    }

    [ProButton]
    public void BeginToMove()
    {
        IsWalkingState = true;
        animator.SetBool(IS_MOVING_ANIM_TAG, IsWalkingState);    
    }

    [ProButton]
    public void StopMoving()
    {
        IsWalkingState = false;
        animator.SetBool(IS_MOVING_ANIM_TAG, IsWalkingState);
    }
}
