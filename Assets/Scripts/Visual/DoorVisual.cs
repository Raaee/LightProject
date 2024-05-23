using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVisual : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip open;
    [SerializeField] private AnimationClip close;
    void Start() {
        animator = GetComponent<Animator>();
        //PlayClose();
    }
    public void PlayOpen() {
        animator.Play(open.name);
    }
    public void PlayClose() {
        animator.Play(close.name);
    }
    public void StopAllAnimations() {
        animator.StopPlayback();
    }
}
