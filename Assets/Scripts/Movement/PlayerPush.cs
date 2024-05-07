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

     private Rigidbody2D box;
    [SerializeField] private Transform lowestPoint;
    [SerializeField] private Transform highestPoint;
    [SerializeField] private bool isHorizontal = true;

    private void Awake()
    {
        box = GetComponent<Rigidbody2D>();
    }
    //Molvement of the box when the player is pushing it
    void Update()
    {

        if (isHorizontal == true)
            DoHorizontal();
        else
            DoVertical();
    }

    private void DoHorizontal()
    {
        box.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
       
        // moves the box to the right and freezes the y position
        if (box.transform.position.x < lowestPoint.position.x)
        {
            box.transform.position = new Vector2(lowestPoint.position.x, box.position.y);          
        }
        // moves the box to the left and freezes the y position
        if (box.transform.position.x > highestPoint.position.x)
        {
            box.transform.position = new Vector2(highestPoint.position.x, box.position.y);
        }
      
    }

    private void DoVertical()
    {
        box.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        // Does not allow the box to go below the lowest point 
        if (box.transform.position.y > lowestPoint.position.y)
        {
            box.transform.position = new Vector2(box.position.x, lowestPoint.position.y);
           
        }
        if (box.transform.position.y < highestPoint.position.y)
        {
            box.transform.position = new Vector2(box.position.x, highestPoint.position.y);
          
        }
    }

    void OnDrawGizmosSelected()
    {
        if (lowestPoint == null || highestPoint == null)
        {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(lowestPoint.position, highestPoint.position);
    }

}


