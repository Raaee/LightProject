using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Vector2 = UnityEngine.Vector2;

public class PlayerPush : MonoBehaviour
{

    [SerializeField] private Rigidbody2D box;
    [SerializeField] private Transform lowestPoint;
    [SerializeField] private Transform highestPoint;


    //Molvement of the box when the player is pushing it
    void Update()
    {
        if (!box)
        {
            Debug.Log("No box");
            return;
        }

        // moves the box to the right and freezes the y position
        if (box.transform.position.x < lowestPoint.position.x)
        {
            box.transform.position = new Vector2(lowestPoint.position.x, box.position.y);
            box.constraints = RigidbodyConstraints2D.FreezePositionY;
            box.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        // moves the box to the left and freezes the y position
        if (box.transform.position.x > highestPoint.position.x)
        {
            box.transform.position = new Vector2(highestPoint.position.x, box.position.y);
            box.constraints = RigidbodyConstraints2D.FreezePositionY;
            box.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        // Does not allow the box to go below the lowest point 
        if (box.transform.position.y > lowestPoint.position.y)
        {
            box.transform.position = new Vector2(box.position.x, lowestPoint.position.y);
            Debug.Log("y");
        }
        if (box.transform.position.y < highestPoint.position.y)
        {
            box.transform.position = new Vector2(box.position.x, highestPoint.position.y);
            Debug.Log("y");
        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            box = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

}


