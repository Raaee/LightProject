using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private LayerMask defaultLayerMask;
    [SerializeField] private LayerMask lightBlockingLayerMask;
    [SerializeField] public List<ILock> locks;
    [SerializeField] private bool isLocked;
    [SerializeField] private bool isRoomDoor;

    [SerializeField] private GameObject player;
    [SerializeField] private DoorDirection doorDirection = DoorDirection.right;

    [SerializeField] private int playerDisplacement = 2;

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
    public void CheckLockStatus() {
        foreach (ILock alock in locks)
        {
            if (alock.IsLocked) {
                LockDoor();
                return;
            }
        }
        UnlockDoor();
    }

    public void UnlockDoor() {
        isLocked = false;
        door.IsLocked = isLocked;
        door.Visual.PlayOpen();
        door.AlertDoorEvent();
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        //this.gameObject.layer = defaultLayerMask.value;
    }

    public void LockDoor() {
        isLocked = true;
        door.IsLocked = isLocked;
        door.Visual.PlayClose();
        door.AlertDoorEvent();
        this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        //this.gameObject.layer = lightBlockingLayerMask.value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRoomDoor) {
            if (collision.CompareTag("Player") && !collision.isTrigger)
            {
                onRoorDoorTransform();
            }
        }
    }

    private void onRoorDoorTransform() {
        switch (doorDirection) {
            case (DoorDirection.right):
                player.transform.position = new Vector2(player.transform.position.x + playerDisplacement, player.transform.position.y);
                break;
            case (DoorDirection.left):
                player.transform.position = new Vector2(player.transform.position.x - playerDisplacement, player.transform.position.y);
                break;
            case (DoorDirection.top):
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + playerDisplacement);
                break;
            case (DoorDirection.down):
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - playerDisplacement);
                break;

        }
    }
}

enum DoorDirection{
    left,
    right,
    top,
    down,
}