using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    [SerializeField] private Transform lowestPoint;
    [SerializeField] private Transform highestPoint;

    //Todo: uncomment one of the lines in Update method and notice how it works in game 
    //TODO: instead of "zero", make it use the value from the "lowest point" or "highest point"
    //Todo: A bool so we can decide if we want a vertical pushhing box or horizontal pushign box 
    //Todo: instead of a "speed" value, add a weight value so it takes longer to push the box -> RigidBody2d.mass = pushableWeight;


    private void Update()
    {
        //this makes the y value to be stuck at one point, but still let the player push the x
        //transform.position = new Vector2(transform.position.x, 0);

        //this makes the y value to be stuck at one point, but still let the player push the y
        //transform.position = new Vector2(0, transform.position.y);
    }



 
    //probably not needed, was thinking it might be helpful
    //if you click on the gameobj in the heirachy you should see a blue line between the 2 transforms
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
