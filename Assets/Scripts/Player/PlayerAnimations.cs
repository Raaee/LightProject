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
    

    private IEnumerator SpawnAnimation()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        float elapsedTime = 0.0f;
        float animationTime = 0.75f;
        float targetScale = 1.0f;
        while (elapsedTime < animationTime)
        {
            // Calculate the lerp value based on elapsed time
            float lerpValue = elapsedTime / animationTime;

            // Use Vector3.Lerp for smooth scaling
            transform.localScale = Vector3.Lerp(new Vector3(0.01f, 0.01f, 0.01f), new Vector3(1f, 1f, 1f), lerpValue);

            // Wait for the next frame to update the scale
            yield return new WaitForEndOfFrame();

            // Update elapsed time
            elapsedTime += Time.deltaTime;
        }
        transform.localScale = new Vector3(targetScale, targetScale, targetScale);
        OnSpawnAnimationEnd?.Invoke();
    }

}
