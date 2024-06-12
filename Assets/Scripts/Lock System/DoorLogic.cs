using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private LayerMask defaultLayerMask;
    [SerializeField] private LayerMask lightBlockingLayerMask;
    [SerializeField] public List<ILock> locks;
    private bool isLocked;
    [SerializeField] private bool isRoomDoor;

    [SerializeField] private GameObject player;
    [SerializeField] private DoorDirection doorDirection = DoorDirection.Right;

    [SerializeField] private int playerDisplacement = 2;

    [HideInInspector] public UnityEvent OnDoorLocked;
    [HideInInspector] public UnityEvent OnDoorUnLocked;
    private bool lockedFromOpen = false;//code for audio to play once 
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        isLocked = true;
        foreach (ILock alock in locks)
        {        
            alock.OnInputDetection.AddListener(CheckLockStatus);
        }
    }

    // DoorLogic can cheack the lock status of multiple locks
    public void CheckLockStatus()
    {
       
        foreach (ILock alock in locks)
        {
            if (alock.IsLocked) {
                LockDoor();
                return;
            }
        }
        UnlockDoor();
    }

    public void UnlockDoor()
    {
        Debug.Log("door has been opened! ");
        isLocked = false;
        door.IsLocked = isLocked;
        door.Visual.PlayOpen();
        door.AlertDoorEvent();
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        this.gameObject.layer = defaultLayerMask.value;
        OnDoorUnLocked?.Invoke();
    }

    public void LockDoor()
    {
       
        if (isLocked)
        {
            lockedFromOpen = false;
            Debug.Log("Doorlogic Already locked, skipping");
            return;
        }
        isLocked = true;
        door.IsLocked = isLocked;
        door.Visual.PlayClose();
        door.AlertDoorEvent();
        this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        this.gameObject.layer = lightBlockingLayerMask.value;
        lockedFromOpen = true;
        OnDoorLocked?.Invoke();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRoomDoor) {
            if (collision.CompareTag("Player") && !collision.isTrigger)
            {
                OnRoorDoorTransform();
            }
        }
    }

    private void OnRoorDoorTransform() {
        switch (doorDirection) {
            case (DoorDirection.Right):
                player.transform.position = new Vector2(player.transform.position.x + playerDisplacement, player.transform.position.y);
                break;
            case (DoorDirection.Left):
                player.transform.position = new Vector2(player.transform.position.x - playerDisplacement, player.transform.position.y);
                break;
            case (DoorDirection.Top):
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + playerDisplacement);
                break;
            case (DoorDirection.Down):
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - playerDisplacement);
                break;

        }
    }

    public bool GetIsDoorLockedFromOpen()
    {
        return lockedFromOpen;
    }
}

enum DoorDirection{
    Left,
    Right,
    Top,
    Down,
}
