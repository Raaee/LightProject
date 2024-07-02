using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    //Add the Scape button interaction

    private Button button;
    [SerializeField] private bool isPause;
    [SerializeField] private InputControls inputControls;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject pauseButton;

    private void Start()

    {
        inputControls = GameObject.FindGameObjectWithTag("Player").GetComponent<InputControls>();
        isPause = false;
        inputControls.OnPause.AddListener(PausingGame);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
    }

    public void PausingGame() {
        isPause = !isPause;
        if (isPause)
        {
            PauseGame();
        }
        else {
            ResumeGame();
        }
    }

    public void PauseGame() {
        isPause = true;
        pauseButton.SetActive(false);
        //inputControls.DisableControls();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        //Audio change
    }

    public void ResumeGame() {
        isPause = false;
        pauseButton.SetActive(true);
        //inputControls.EnableControls();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        //Revert audio change
    }

    public void OpenSettting() {
        settingMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ReturnToPauseMenu() {
        settingMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void BackToMeinMenu() {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu_");
        Debug.Log("Return To Main Menu");
    }
 
    
}
