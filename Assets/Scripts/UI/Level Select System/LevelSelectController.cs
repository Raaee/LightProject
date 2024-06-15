using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSelectController : MonoBehaviour
{
   
    public List<LevelSelectElementSO> levelElements;
    private int currentLevelSelected = 0;
    public UnityEvent<int> OnCurrentLevelSelectChange;

    private void Start()
    {
        if (levelElements.Count < 3)
            Debug.LogError("Make sure theres at least 3 elements in the list");
    }
    
    //Buttons to go right or left
    public void OnSelectNextLevel()
    {
        currentLevelSelected++;
        if (currentLevelSelected == levelElements.Count - 1)
            currentLevelSelected = 0;
        OnCurrentLevelSelectChange?.Invoke(currentLevelSelected);
    }
    public void OnSelectPreviousLevel()
    {
        currentLevelSelected--;
        if (currentLevelSelected == -1)
            currentLevelSelected = levelElements.Count - 1;
        OnCurrentLevelSelectChange?.Invoke(currentLevelSelected);
    }

    //Todo: implement validation systme
    private void ValidateAllLevelElements()
    {
        
    }
}
