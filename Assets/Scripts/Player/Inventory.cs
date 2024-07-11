using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private float itemHoldOffset = -0.5f;
    [field:SerializeField] public GameObject inventory { get; private set; }
    [HideInInspector] public UnityEvent OnItemPickedUp;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }
    private void Start()
    {
        inventory = null;
    }    

    public void AddItem(GameObject item)    {
      
        if (!inventory) {
            inventory = item;       
            inventory.transform.SetParent(transform);
            inventory.transform.position = new Vector3(transform.position.x + itemHoldOffset, transform.position.y, 0);
            OnItemPickedUp?.Invoke();
        }
        else
        {
        }
    }
    public void RemoveItem()
    {
        if (inventory)
        {
            Destroy(inventory);
            inventory = null;
        }
        else
        {
        }
    }
}
