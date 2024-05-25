using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ILock : MonoBehaviour
{
    
    [SerializeField] protected LaserKeys laserKey;
    [HideInInspector] public UnityEvent OnInputDetection;
    [SerializeField] protected LockVisual visual;
    [field:SerializeField] public bool IsLocked { get; protected set; }
    public abstract void Unlock();
    public abstract void Lock();
    public LaserKeys GetLaserKey() { return laserKey; }

}
