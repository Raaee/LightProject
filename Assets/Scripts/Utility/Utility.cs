using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    //static keywords for save and load
    public static string CURRENT_LEVEL_KEY = "currentLevel";
    public static string SFX_VOLUME_KEY = "sfxVolumeKey";
    public static string MUSIC_VOLUME_KEY = "musicVolumeKey";
    public  static string BRIGHTNESS_SELECTION_KEY = "brightnessSelectionKey";

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
    public static Quaternion GetRotationFromDirection(CardinalDirection dir) {
        Quaternion rotation = Quaternion.identity;
        Vector2 direction = GetUnitVector(dir);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0, 0, -angle);
        return rotation;
    }
    public static Vector3 GetVectorFromAngle(float angle) {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static int GetRandomIndexNonRepeat(int lastRepeatedIndex, int sizeOfList)
    {
        List<int> indexList = new List<int>();
        for (int i = 0; i < sizeOfList; i++)
        {
            indexList.Add(i);
        }

        indexList.Remove(lastRepeatedIndex);
        int chosenIndex = Random.Range(0, indexList.Count);
        
        return indexList[chosenIndex];
    }

   
    
    
}
