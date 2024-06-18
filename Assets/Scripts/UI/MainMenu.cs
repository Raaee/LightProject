
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

    public void StartGameplayLevel()
    {
        //check easy save for current progress + also check to skip tutorial?
        //go to that level based on progress 
        Debug.Log("Starting gameplay scene...sike lol");
    }


    private void Start()
    {
        CloseSettingsPanel();
        CloseLevelPanel();
    }


    public void OpenSettingsPanel()
    {
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
