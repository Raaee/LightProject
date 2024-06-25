using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : EditorWindow
{
    List<SceneAsset> m_SceneAssets = new List<SceneAsset>();

    // Add menu item named "Scene Helper" to the Window menu
    [MenuItem("Pete Helper Debug/Build Scenes Helper")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(SceneHelper));
    }
    
    [MenuItem("Pete Helper Debug/Copy Scene Path")]
    public static void GetScenePathToClipboard()
    {
        var scenePath = SceneManager.GetActiveScene().path;
        CopyToClipboard(scenePath);
        Debug.Log("Copied '" + scenePath + "' to clipboard!  ");
    }
    
   static void CopyToClipboard(string text) 
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = text;
        textEditor.SelectAll();
        textEditor.Copy();
    }

    void OnGUI()
    {
        GUILayout.Label("Scenes to include in build:", EditorStyles.boldLabel);
        for (int i = 0; i < m_SceneAssets.Count; ++i)
        {
            m_SceneAssets[i] = (SceneAsset)EditorGUILayout.ObjectField(m_SceneAssets[i], typeof(SceneAsset), false);
        }
        if (GUILayout.Button("Add"))
        {
            m_SceneAssets.Add(null);
        }

        GUILayout.Space(8);
        GUILayout.Label("WARNING: THIS WILL OVERRIDE CURRENT BUILD INDEX. im looking at you raeus:", EditorStyles.helpBox);
        if (GUILayout.Button("Apply To Build Settings."))
        {
            SetEditorBuildSettingsScenes();
        }
    }
//TODO: hardcode main menu scene and end game scene to be added to the build index
    public void SetEditorBuildSettingsScenes()
    {
        // Find valid Scene paths and make a list of EditorBuildSettingsScene
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        foreach (var sceneAsset in m_SceneAssets)
        {
            string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            if (!string.IsNullOrEmpty(scenePath))
                editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
        }

        // Set the Build Settings window Scene list
        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
    }
}
