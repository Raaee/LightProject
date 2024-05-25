using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Vector2 = UnityEngine.Vector2;

public class Pushable : MonoBehaviour
{
    private Rigidbody2D box;
    [SerializeField] private ChainVisual chain;
    [SerializeField] private PushDirection pushDirection = PushDirection.HORIZONTAL;
    [SerializeField] private float pushableRange = 3f;
    private Transform initialPosition;
    private Vector2 lowestPoint; // left OR bottom
    private Vector2 highestPoint; // right OR top

    private void Awake()
    {
        box = GetComponent<Rigidbody2D>();
    }
    void Start() {
        initialPosition = transform;
        SetPoints();        
    }
    void Update()
    {
        switch (pushDirection)
        {
            case PushDirection.HORIZONTAL:
                DoHorizontal();
                chain.HorizontalSprite();
                break;
            case PushDirection.VERTICAL:
                DoVertical();
                chain.VerticalSprite();
                break;
            default:
                Debug.LogError("Not supposed to be here!");
                break;
        }
    }

    private void DoHorizontal()
    {
        box.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
       
        // moves the box to the right and freezes the y position
        if (box.transform.position.x < lowestPoint.x)
        {
            box.transform.position = new Vector2(lowestPoint.x, box.position.y);          
        }
        // moves the box to the left and freezes the y position
        if (box.transform.position.x > highestPoint.x)
        {
            box.transform.position = new Vector2(highestPoint.x, box.position.y);
        }
      
    }

    private void DoVertical()
    {
        box.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
       
        // Does not allow the box to go below the lowest point 
        if (box.transform.position.y < lowestPoint.y)
        {
            box.transform.position = new Vector2(box.position.x, lowestPoint.y);
           
        }
        if (box.transform.position.y > highestPoint.y)
        {
            box.transform.position = new Vector2(box.position.x, highestPoint.y);
          
        }
    }
    private void SetPoints() {
        switch (pushDirection)
        {
            case PushDirection.HORIZONTAL:
                lowestPoint = new Vector2(initialPosition.position.x - pushableRange, initialPosition.position.y);
                highestPoint = new Vector2(initialPosition.position.x + pushableRange, initialPosition.position.y);
                break;
            case PushDirection.VERTICAL:
                lowestPoint = new Vector2(initialPosition.position.x, initialPosition.position.y - pushableRange);
                highestPoint = new Vector2(initialPosition.position.x, initialPosition.position.y + pushableRange);
                break;
            default:
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (lowestPoint == null || highestPoint == null)
        {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(lowestPoint, highestPoint);
    }

}

public enum PushDirection
{
    HORIZONTAL,
    VERTICAL
}


