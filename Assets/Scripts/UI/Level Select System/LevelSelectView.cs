using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectView : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectUIPrefab;
    [SerializeField] private GameObject levelSelectGrid;
    private List<LevelSelectUIData> levelUIDatas;
    private const int AMOUNT_OF_LEVELS = 3;

    public List<LevelSelectElementSO> testLevelSelectSos;
    private void Start()
    {
        DestroyChildren(levelSelectGrid.transform); //clean up anything still in scene after play
        levelUIDatas = new List<LevelSelectUIData>();
        for (int i = 0; i < AMOUNT_OF_LEVELS; i++)
        {
            var levelInstance = Instantiate(levelSelectUIPrefab, levelSelectGrid.transform);
            levelUIDatas.Add(levelInstance.GetComponent<LevelSelectUIData>());
        }

        DEBUG_DisplayAllLevels();
    }

    private void DEBUG_DisplayAllLevels()
    {
        for (int i = 0; i < AMOUNT_OF_LEVELS; i++)
        {
            DisplayLevel(testLevelSelectSos[i], levelUIDatas[i]);
        }
        
    }


    private void DisplayLevel(LevelSelectElementSO levelSo, LevelSelectUIData levelUIData )
    {
        levelUIData.TitleText.text = levelSo.titleOfLevel;
        levelUIData.DevNameText.text = "Created by: " + levelSo.developerName;
        levelUIData.GameImage.sprite = levelSo.levelPicture;
    }

    private void DestroyChildren(Transform parentTransform)
    {
        foreach(Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
    }
   
}
