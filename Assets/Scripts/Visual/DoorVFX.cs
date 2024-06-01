using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorVFX : MonoBehaviour
{
    [SerializeField] protected ParticleSystem particleSystem;

    public abstract void PlayOpen();
    public abstract void PlayClose();
}
