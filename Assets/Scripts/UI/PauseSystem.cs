using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseSystem : MonoBehaviour
{
    //Add the Scape button interaction


    private bool isPause = false;
    private InputControls inputControls;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject pauseButtonPanel;
     [SerializeField] private UIFade fadeSystem;
    private PlayerMovement playerMovement;

    private void Start()

    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        inputControls = playerMovement.gameObject.GetComponent<InputControls>();
        inputControls.OnPause.AddListener(OnPauseGame);
        fadeSystem.OnFadeOutComplete.AddListener(LoadMainMenu);

        pauseButtonPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void OnPauseGame()
    {
        isPause = !isPause;
        if (isPause)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPause = true;
        pauseButtonPanel.SetActive(false);
        //inputControls.DisableControls();
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
        //Audio change
        PauseSnapshot.Instance.StartPauseAudio();
    }

    public void ResumeGame()
    {
        isPause = false;
        pauseButtonPanel.SetActive(true);
        //inputControls.EnableControls();
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        //Revert audio change
        PauseSnapshot.Instance.StopPauseAudio();

    }

    public void BackToMeinMenu()
    {
        Time.timeScale = 1;
        fadeSystem.FadeOut();
        Debug.Log("Return To Main Menu");
    }

    private void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu_");
    }
}