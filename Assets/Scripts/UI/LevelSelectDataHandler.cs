using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectDataHandler : PersistentSingleton<LevelSelectDataHandler>
{
  public List<LevelSelectElementSO> levelElements;
  public Dictionary<String, String> SceneToDialogueMapping { get; private set; }

  protected override void Awake()
  {
    base.Awake();
    SceneToDialogueMapping = new Dictionary<string, string>();
    foreach (var levelElement in levelElements)
    {
      SceneToDialogueMapping.Add(levelElement.scenePath, levelElement.dialogueText);
    }
  }
}
