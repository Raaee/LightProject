using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectView : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectUIPrefab;
    [SerializeField] private GameObject levelSelectGrid;
    private List<LevelSelectUIData> levelUIDatas;
    private int AMOUNT_OF_LEVELS = 3;
    private LevelSelectController levelSelectController;
  
    private void Start()
    {
        levelSelectController = GetComponent<LevelSelectController>();
      
        AMOUNT_OF_LEVELS = levelSelectController.levelElements.Count;
        Initialize();
    }

    public void OnPlaySelectedLevel()
    {
        //TODO: remove bad code of find obj of type
        int levelIndex = FindObjectOfType<ScrollViewSnapToItem>().GetCurrentItem();
        var selectedLevelScenePath = levelSelectController.levelElements[levelIndex].scenePath;
        SceneController.Instance.GoToScene(selectedLevelScenePath);
    }

    private void DisplayLevelsToScreen(int currentLevelIndex)
    {
        var listOfLevelElements = levelSelectController.levelElements;
        int previousLevelIndex = (currentLevelIndex - 1 + listOfLevelElements.Count) % listOfLevelElements.Count;
        int nextLevelIndex = (currentLevelIndex + 1) % listOfLevelElements.Count;

        DisplayLevel(listOfLevelElements[previousLevelIndex], levelUIDatas[0]);
        DisplayLevel(listOfLevelElements[currentLevelIndex], levelUIDatas[1]);
        DisplayLevel(listOfLevelElements[nextLevelIndex], levelUIDatas[2]);

    }

    private void Initialize()
    {
        DestroyChildren(levelSelectGrid.transform); //clean up anything still in scene after play
        levelUIDatas = new List<LevelSelectUIData>();
        for (int i = 0; i < AMOUNT_OF_LEVELS; i++)
        {
            var levelInstance = Instantiate(levelSelectUIPrefab, levelSelectGrid.transform);
            levelUIDatas.Add(levelInstance.GetComponent<LevelSelectUIData>());
            var listOfLevelElements = levelSelectController.levelElements;
            DisplayLevel(listOfLevelElements[i], levelInstance.GetComponent<LevelSelectUIData>());
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
