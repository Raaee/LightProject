using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ILock : MonoBehaviour
{
    public bool lockStatus;
    public UnityEvent OnlaserDetected;
    public abstract void Unlock();
    public abstract void Lock();

}
