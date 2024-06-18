using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : PersistentSingleton<SceneController>
{


    public void GoToScene(string scenePath)
    {
       bool isSceneValid = SceneManager.GetSceneByPath(scenePath).IsValid();
       if (!isSceneValid)
       {
           SceneManager.LoadScene(scenePath);
       }
       else
       {
           Debug.LogError("We going nowhere cause this scene:'" + scenePath + "' is invalid. ");
       }
    }
    
    
   
}
