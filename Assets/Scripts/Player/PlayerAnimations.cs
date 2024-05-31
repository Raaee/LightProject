using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip idle_UP;
    [SerializeField] private AnimationClip idle_DOWN;
    [SerializeField] private AnimationClip moving;
    [SerializeField] private AnimationClip moveToIdleTransition;
    [SerializeField] private AnimationClip idleToMoveTransition;

    private void Start() {
        
    }
    public void PlayIdle() {
        animator.Play(moveToIdleTransition.name);
        animator.SetBool("Idling", true);
    }
    public void PlayMove() {
        animator.Play(idleToMoveTransition.name);
        animator.SetBool("Moving", true);
    }
}
