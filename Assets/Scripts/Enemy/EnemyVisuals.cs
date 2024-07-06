using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkyCode;

public class EnemyVisuals : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator animator;
    [SerializeField] private Light2D FoVLight;
    [SerializeField] private Light2D auraLight;
    [SerializeField] private AnimationClip spawn;
    [SerializeField] private AnimationClip idle;
    [SerializeField] private AnimationClip detect;

    private void Start() {
        Spawn();
    }
    public void StopGlitch() {
        sr.material.SetFloat("_HandDrawnAmount", 0);
        sr.material.SetFloat("_HandDrawnSpeed", 0);
    }
    public void PlayGlitch() {
        sr.material.SetFloat("_HandDrawnAmount", 10);
        sr.material.SetFloat("_HandDrawnSpeed", 5);
    }
    public void PlayDetect() {
        animator.Play(detect.name);
    }
    public void DisableLight() {
        FoVLight.enabled = false;
        auraLight.enabled = false;
    }
    public void EnableLight() {
        FoVLight.enabled = true;
        auraLight.enabled = true;
    }
    private void Spawn() {
        animator.Play(spawn.name);
        EnableLight();
        StopGlitch();
    }
    public void Moving(bool isMove) {
        animator.SetBool("isMoving", isMove);
    }
}
