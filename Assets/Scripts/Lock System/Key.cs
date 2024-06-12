using System.Collections;
using System.Collections.Generic;
using FunkyCode.Rendering.Day;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    //Picking up the key 
    public void Interact()
    {
        Inventory.instance.AddItem(this.gameObject.transform.parent.gameObject);
        this.gameObject.GetComponentInParent<Collider2D>().enabled = false;
    }
}
