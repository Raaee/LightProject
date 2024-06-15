using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
   
    public List<LevelSelectElementSO> levelElements;
    private int currentLevelSelected = 0; 

    private void Start()
    {
        if (levelElements.Count < 3)
            Debug.LogError("Make sure theres at least 3 elements in the list");
    }
    
    //Buttons to go right or left
    public void OnSelectNextLevel()
    {
      
    }
    public void OnSelectPreviousLevel()
    {
      
    }

    //Todo: implement validation systme
    private void ValidateAllLevelElements()
    {
        
    }
}
