using System.Collections;
using System.Collections.Generic;
using FunkyCode.Rendering.Day;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    //Picking up the key 
    public void Interact()
    {
        Debug.Log("Key",this.gameObject);
        Inventory.instance.AddItem(this.gameObject);
    }
}
