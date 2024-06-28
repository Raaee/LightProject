
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject levelSelectPanel;
    
    //TODO: refactor scene loading into seperate class
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene(0);
    }

   
    public void StartGameplayLevel() //StartOrContinue Gameplay Level
    {
        //TODO: also check to skip tutorial?
    
        //RAE approach
        //gameplayScenesList
        //when level ends, currentLevel++ -> ES3.Save("currentLevel", currentLevel); 
        // when play next level  = int index =  ES3.Load("currentLevel", currentLevel)
        //LoadScene(gameplayScenesList[index].name)
        //TODO: PRINT ALL CURRENT SAVED DATA AS UTILITY BUTTON
        int index = ES3.Load(Utility.CURRENT_LEVEL_KEY, 0);
        Debug.Log("Rae - On level: " + LevelSelectDataHandler.Instance.gamePlayLevelElements[index].scenePath + " Index is " + index);
        SceneManager.LoadScene(LevelSelectDataHandler.Instance.gamePlayLevelElements[index].scenePath);
    }


    private void Start()
    {
        CloseSettingsPanel();
        CloseLevelPanel();
    }


    public void OpenSettingsPanel()
    {
        Debug.Log("opening settings");
        settingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    
    public void OpenLevelPanel()
    {
        levelSelectPanel.SetActive(true);
    }
    public void CloseLevelPanel()
    {
        levelSelectPanel.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
