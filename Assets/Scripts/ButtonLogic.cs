using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    //Add the Scape button interaction

    [SerializeField] private InputControls inputControls;
    private Button button;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject pauseButton;

    private void Start()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
    }

    public void PauseGame() {
        pauseButton.SetActive(false);
        inputControls.DisableControls();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        //Audio change
    }

    public void ResumeGame() {
        pauseButton.SetActive(true);
        inputControls.EnableControls();
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
        Debug.Log("Return To Main Menu");
    }
 
}
