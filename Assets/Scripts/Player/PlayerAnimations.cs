using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    public bool IsWalkingState { get; set; }
    private const string IS_MOVING_ANIM_TAG = "isMoving";

    private void Start()
    {
        IsWalkingState = false;
        animator.SetBool(IS_MOVING_ANIM_TAG, IsWalkingState);
        playerMovement.OnPlayerMove.AddListener(BeginToMove);
        playerMovement.OnPlayerStop.AddListener(StopMoving);
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
