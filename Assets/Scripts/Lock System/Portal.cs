
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Door door;

    private void Awake()
    {
        door = GetComponent<Door>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement potentialPlayer = collision.gameObject.GetComponent<PlayerMovement>();
        if (potentialPlayer == null) return;
        if (door.IsLocked == true) return;

        Debug.Log("Going to Next Level...321");
       
        //freeze player 
        //play teleport animation 
        //sfx 
        //singleton instance thingy to show next level/menu panel 
    }

}
//NICE TO HAVE: BE QUIET RAE... take a snapshot of the winning level and saves it, so players can easily see/show their solutions