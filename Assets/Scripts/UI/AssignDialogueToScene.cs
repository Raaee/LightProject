using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssignDialogueToScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winGameDialogueText;

    private void Start()
    {
        var currentScenePath = SceneManager.GetActiveScene().path;
        
        if (LevelSelectDataHandler.Instance == null)
            return;
        if(LevelSelectDataHandler.Instance.SceneToDialogueMapping != null)
            winGameDialogueText.text =
                LevelSelectDataHandler.Instance.SceneToDialogueMapping.GetValueOrDefault(currentScenePath, "You cannot Escape");
    }
}
