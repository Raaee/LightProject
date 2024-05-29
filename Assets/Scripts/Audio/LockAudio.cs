using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAudio : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private FMODUnity.EventReference lockSfx;
    [SerializeField] private FMODUnity.EventReference unlockSfx;

    private void PlayLockSfx()
    {
        FMODUnity.RuntimeManager.PlayOneShot(lockSfx, transform.position);
    }

    private void PlayUnLockSfx()
    {
        FMODUnity.RuntimeManager.PlayOneShot(unlockSfx, transform.position);
    }
}
