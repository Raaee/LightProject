using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ILock : MonoBehaviour
{
    
    public UnityEvent OnInputDetection;
    [field:SerializeField] public bool IsLocked { get; protected set; }
    public abstract void Unlock();
    public abstract void Lock();

}
