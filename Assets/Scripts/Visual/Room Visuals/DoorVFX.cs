using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class DoorVFX : MonoBehaviour
{
    [FormerlySerializedAs("particleSystem")] [SerializeField] protected ParticleSystem doorVfxParticleSystem;

    public abstract void PlayOpen();
    public abstract void PlayClose();
}
