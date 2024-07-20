using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSelectController : MonoBehaviour
{
   
    //TODO: this is useless claasss, justr move this list to the view vlass or even the scene controller singleton 
    public List<LevelSelectElementSO> levelElements;
    
    

    private void Start()
    {
        if (levelElements.Count < 3)
            Debug.LogError("Make sure theres at least 3 elements in the list");

        levelElements = LevelSelectDataHandler.Instance.sandboxLevelElements;
    }
    
    
    //Todo: implement validation systme
    private void ValidateAllLevelElements()
    {
        
    }
}
