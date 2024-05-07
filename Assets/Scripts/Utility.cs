using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{

    public static Vector2 GetOffsetPosition(Vector2 currentPosition, float distance, CardinalDirection laserBeamOrientation)
    {
        Vector2 unitVector = GetUnitVector(laserBeamOrientation);
        return currentPosition + unitVector * distance;
    }

    public static Vector2 GetUnitVector(CardinalDirection direction)
    {
        if (direction == CardinalDirection.NORTH)
        {
            return new Vector2(0, 1);
        }
        else if (direction == CardinalDirection.NORTH_EAST)
        {
            return new Vector2(Mathf.Sqrt(2) / 2, Mathf.Sqrt(2) / 2);
        }
        else if (direction == CardinalDirection.EAST)
        {
            return new Vector2(1, 0);
        }
        else if (direction == CardinalDirection.SOUTH_EAST)
        {
            return new Vector2(Mathf.Sqrt(2) / 2, -Mathf.Sqrt(2) / 2);
        }
        else if (direction == CardinalDirection.SOUTH)
        {
            return new Vector2(0, -1);
        }
        else if (direction == CardinalDirection.SOUTH_WEST)
        {
            return new Vector2(-Mathf.Sqrt(2) / 2, -Mathf.Sqrt(2) / 2);
        }
        else if (direction == CardinalDirection.WEST)
        {
            return new Vector2(-1, 0);
        }
        else if (direction == CardinalDirection.NORTH_WEST)
        {
            return new Vector2(-Mathf.Sqrt(2) / 2, Mathf.Sqrt(2) / 2);
        }
        else
        {
            // Handle NONE or any unexpected direction (optional)
            Debug.Log("You bum, its none of the cardinal directions");
            return new Vector2(0, 0); // Or throw an exception
        }
    }
}
