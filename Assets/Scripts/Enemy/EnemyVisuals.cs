using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkyCode;

public class EnemyVisuals : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Light2D FoVLight;
    [SerializeField] private Light2D auraLight;
    [SerializeField] private AnimationClip spawn;
    [SerializeField] private AnimationClip idle;
    [SerializeField] private AnimationClip detect;

    private void Start() {
        Spawn();
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
    public void Spawn() {
        animator.Play(spawn.name);
        EnableLight();
    }
    public void Moving(bool isMove) {
        animator.SetBool("isMoving", isMove);
    }
}
