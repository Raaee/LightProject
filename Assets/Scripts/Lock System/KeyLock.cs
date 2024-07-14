using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class KeyLock : ILock, IInteractable
{
    public UnityEvent OnKeyLockPlaced;
    void Start()
    {
        laserKey = LaserKeys.KEY;
        Lock();
    }
    public void Interact()
    {
        if (IsLocked && Inventory.instance.inventory && Inventory.instance.inventory.GetComponentInChildren<Key>())
        {
            Debug.Log("unlocking key lock");
            OnKeyLockPlaced?.Invoke();
            Inventory.instance.RemoveItem();
            Unlock();
        }
        OnInputDetection.Invoke();
    }
    public override void Unlock()
    {
        Debug.Log("Unlocking");
        IsLocked = false;
        visual.UnlockSprite();
    }
    public override void Lock()
    {
        IsLocked = true;
        visual.LockSprite();
    }

}
