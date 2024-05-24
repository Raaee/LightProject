using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyLock : ILock, IInteractable
{
    void Start()
    {
        Lock();
    }
    public void Interact()
    {
        if (Inventory.instance.inventory.GetComponent<Key>())
        {
            Debug.Log("unlocking key lock");
            Inventory.instance.RemoveItem();
            Unlock();
        }
        OnInputDetection.Invoke();
    }
    public override void Unlock()
    {
        IsLocked = false;
        visual.UnlockSprite();
    }
    public override void Lock()
    {
        IsLocked = true;
        visual.LockSprite();
    }

}
