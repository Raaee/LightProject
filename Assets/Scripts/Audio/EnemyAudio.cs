using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference enemyYell;
    [SerializeField] private FieldOfViewDetection enemyDetection;

  
    private float delayTime = 2f;
    private bool canYell = true;

   
    //add a time delay so it doesnt spam?

    void Awake()
    {
        enemyDetection.OnPlayerDetect.AddListener(PlayEnemyYell);
    }


    public void PlayEnemyYell()
    {

        if (canYell)
        {
            RuntimeManager.PlayOneShot(enemyYell);
            canYell = false;
            StartCoroutine(speechDelay());
        }
       

    }

    private IEnumerator speechDelay()
    {

        yield return new WaitForSeconds(delayTime);
        canYell = true;
    }
}