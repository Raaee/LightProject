using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ILock : MonoBehaviour
{
    
    [HideInInspector] public UnityEvent OnInputDetection;
    [SerializeField] protected LockVisual visual;
    [field:SerializeField] public bool IsLocked { get; protected set; }
    public abstract void Unlock();
    public abstract void Lock();

}
