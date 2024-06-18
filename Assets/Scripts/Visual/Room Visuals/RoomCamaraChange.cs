using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamaraChange : MonoBehaviour
{
    public GameObject virtualCamara;

    private void Start()
    {
        virtualCamara = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) {
            virtualCamara.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamara.SetActive(false);
        }
    }
}
