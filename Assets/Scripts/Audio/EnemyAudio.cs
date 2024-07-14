using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
     [SerializeField] private FMODUnity.EventReference enemyYell;
    [SerializeField] private FieldOfViewDetection enemyDetection;

    //add a time delay so it doesnt spam?

    void Awake()
    {
        enemyDetection.OnPlayerDetect.AddListener(PlayEnemyYell);
    }


   public void PlayEnemyYell()
   {
    Debug.Log("playing enemy yell");
   }
}
