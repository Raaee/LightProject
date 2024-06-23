
using UnityEngine;


/// <summary>
/// A Manager singleton made for saving and loading data. 
/// </summary>
public class SaveManager : PersistentSingleton<SaveManager>
{
   //TODO: level completed state feature 
   private int currentLevel = 1; //level 1 is gameplayScene[0]
   
   private float savedSfxVolume = 0.75f; //from 0.01 to 1.0f
   
   private float savedMusicVolume = 0.75f;
   
   private BrightnessProfileSelection brightnessProfileSelection = BrightnessProfileSelection.LOW_BRIGHT; 
   
   protected override void Awake()
   {
      base.Awake();
   }

  
   public void ResetAllKeys() //duplicated code in SceneHelper script
   {
      ES3.Save(Utility.CURRENT_LEVEL_KEY, 1);
      ES3.Save(Utility.SFX_VOLUME_KEY, 0.75f);
      ES3.Save(Utility.MUSIC_VOLUME_KEY, 0.75f);
      ES3.Save(Utility.BRIGHTNESS_SELECTION_KEY, BrightnessProfileSelection.LOW_BRIGHT);
      Debug.Log("All keys reset to default setting! Called in game");
   }

   public void OnNextLevelProgressed()
   {
      if(ES3.KeyExists(Utility.CURRENT_LEVEL_KEY))
         currentLevel = ES3.Load(Utility.CURRENT_LEVEL_KEY, 1);
      else
      {
         ES3.Save<int>(Utility.CURRENT_LEVEL_KEY, 1);
         Debug.LogWarning("Save data for 'Current Level' didnt exist yet. setting it up right now! ");
      }

      currentLevel++;
      ES3.Save(Utility.CURRENT_LEVEL_KEY, currentLevel );
   }

   
   public void SaveBrightnessSelection(BrightnessProfileSelection newBps)
   {
      ES3.Save(Utility.BRIGHTNESS_SELECTION_KEY, newBps);
   }
   
}
