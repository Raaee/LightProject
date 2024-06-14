
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu]
public class LevelSelectElementSO : ScriptableObject
{
   public string titleOfLevel;
   
   
   public string scenePath; //will be set with a tool, create a tool to quickly get the scene path of a scene 
   public Sprite levelPicture;
   private int levelNumber = 0; // will be set by the handler (index + 1)

   [Header("Optional: These features may or may not be in the game")]
   public DEV_NAME developerName;
   [TextArea] public string dialogueText;

   
   public void SetLevelNumber(int index)
   {
      levelNumber = index + 1;
   }
}

public enum DEV_NAME
{
   None,
   Issac,
   Ally,
   Alice,
   Raeus,
   Peterson
}