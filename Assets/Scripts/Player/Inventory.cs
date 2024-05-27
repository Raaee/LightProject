using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    //[SerializeField] private int inventorySpace = 1;
    [SerializeField] private float itemHoldOffset = -0.5f;
    [field:SerializeField] public GameObject inventory { get; private set; }
    private InputControls inputControls;

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
        inputControls = GetComponent<InputControls>();
        inputControls.OnInteract.AddListener(TryDropInventory);
    }    

    public void AddItem(GameObject item)
    {
        if (!inventory)
        {
            inventory = item;
            inventory.transform.SetParent(transform);
            inventory.transform.position = new Vector3(transform.position.x + itemHoldOffset, transform.position.y, 0);
        }
        else
        {
            Debug.Log("Inventory is full");
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
            Debug.Log("Inventory is empty");
        }
    }

    private void TryDropInventory()
    {
        if(inventory)
        {
            inventory.transform.position = new Vector3(transform.position.x + itemHoldOffset, transform.position.y, 0);
            inventory.transform.SetParent(null);
            inventory = null;
        }
        else
        {
           // Debug.Log("Inventory is empty");
        }
    }

    


}
