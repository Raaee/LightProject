using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;
    [SerializeField] private int inventorySpace = 1;
    [field:SerializeField] public GameObject inventory { get; private set; }
    private float keyPositionOffset = 1.5f;
    private InputControls inputControls;

    private void Start()
    {
        inputControls = GetComponent<InputControls>();
        inputControls.OnInteract.AddListener(DropInventory);
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {

            Destroy(this);
        }else
        instance = this;
    }

    public void AddItem(GameObject item)
    {
        if (!inventory)
        {
            inventory = item;
            inventory.transform.SetParent(transform);
            inventory.transform.position = new Vector3(transform.position.x + keyPositionOffset, transform.position.y, 0);
            
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

    public void DropInventory()
    {
        if(inventory)
        {
            inventory.transform.position = new Vector3(transform.position.x + keyPositionOffset, transform.position.y, 0);
            inventory.transform.SetParent(null);
            inventory = null;
        }
        else
        {
            Debug.Log("Inventory is empty");
        }
    }

    


}
