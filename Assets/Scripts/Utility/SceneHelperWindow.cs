using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneHelperWindow : EditorWindow
{
  
  
    
    
    [MenuItem("Pete Helper Debug/Reset level Data")]
    public static void ResetLevelData()
    {
        ES3.Save(Utility.CURRENT_LEVEL_KEY, 1);
        Debug.Log("Reseting level data from pete debug helper.");
    }
    
    [MenuItem("Pete Helper Debug/Reset all Save Data")]
    public static void ResetAllSaveData()
    {
     
        ES3.Save(Utility.CURRENT_LEVEL_KEY, 1);
        ES3.Save(Utility.SFX_VOLUME_KEY, 0.75f);
        ES3.Save(Utility.MUSIC_VOLUME_KEY, 0.75f);
        ES3.Save(Utility.BRIGHTNESS_SELECTION_KEY, BrightnessProfileSelection.LOW_BRIGHT);
        Debug.Log("Reseting all save data from pete debug helper.");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy
        Label label = new Label("Hello World!");
        root.Add(label);

        // Create button
        Button button = new Button();
        button.name = "button";
        button.text = "Button";
        root.Add(button);

        // Create toggle
        Toggle toggle = new Toggle();
        toggle.name = "toggle";
        toggle.label = "Toggle";
        root.Add(toggle);
    }
}
