
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject levelSelectPanel;
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene(0);
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
        Debug.Log("clcik recognized");
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
