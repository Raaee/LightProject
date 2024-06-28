
using UnityEngine;


/// <summary>
/// A Manager singleton made for saving and loading data. 
/// </summary>
public class SaveManager : PersistentSingleton<SaveManager>
{
   //TODO: level completed state feature 
   private int currentLevel = 0; 
   
   protected override void Awake()
   {
      base.Awake();
      ES3.Save(Utility.CURRENT_LEVEL_KEY, 0);
     currentLevel = ES3.Load(Utility.CURRENT_LEVEL_KEY, 0);

   }

  
   public void ResetAllKeys() //duplicated code in SceneHelper script
   {
      ES3.Save(Utility.CURRENT_LEVEL_KEY, 0);
      ES3.Save(Utility.SFX_VOLUME_KEY, 0.75f);
      ES3.Save(Utility.MUSIC_VOLUME_KEY, 0.75f);
      ES3.Save(Utility.BRIGHTNESS_SELECTION_KEY, BrightnessProfileSelection.LOW_BRIGHT);
      Debug.Log("All keys reset to default setting! Called in game");
   }

   public void OnNextLevelProgressed()
   {
      currentLevel++;
      ES3.Save(Utility.CURRENT_LEVEL_KEY, currentLevel );
   }

 
   
}
