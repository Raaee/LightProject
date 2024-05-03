using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerPush : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float speed = 0.5f;
    [SerializeField] private Rigidbody2D box;
    [SerializeField] private Transform lowestPoint;
    [SerializeField] private Transform highestPoint;

    //private LayerMask boxMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!box)
        {
            Debug.Log("No box");
            return;

        }
        return;
        box.transform.position = new Vector2(box.transform.position.x, 0);
        
        // Physics2D.queriesStartInColliders = false;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, boxMask);
        if (box.transform.position.x <= lowestPoint.position.x)
        {
            box.transform.position = new Vector2(lowestPoint.position.x, 0);
            Debug.Log("x");
        }
        if (box.transform.position.x > highestPoint.position.x)
        {
            box.transform.position = new Vector2(highestPoint.position.x, 0);
            Debug.Log("x");
        }

        if (box.transform.position.y < lowestPoint.position.y)
        {
            box.transform.position = new Vector2(lowestPoint.position.x, 0);

            Debug.Log("y");

        }

        if (box.transform.position.y > highestPoint.position.y)
        {
            box.transform.position = new Vector2(highestPoint.position.x, 0);

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

