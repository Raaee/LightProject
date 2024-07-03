using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelSelectDataHandler : PersistentSingleton<LevelSelectDataHandler>
{ //should be a prefab
  public List<LevelSelectElementSO> sandboxLevelElements;
  public List<LevelSelectElementSO> gamePlayLevelElements;
  public Dictionary<String, String> SceneToDialogueMapping { get; private set; }

  protected override void Awake()
  {
    base.Awake();
    if (sandboxLevelElements.Count == 0 || gamePlayLevelElements.Count == 0)
      return;
    SceneToDialogueMapping = new Dictionary<string, string>();
    
    foreach (var levelElement in sandboxLevelElements)
    {
      SceneToDialogueMapping.Add(levelElement.scenePath, levelElement.dialogueText);
    }
  }
}
