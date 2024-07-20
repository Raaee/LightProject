using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseSystem : MonoBehaviour
{
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
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
        //Audio change
        PauseSnapshot.Instance.StartPauseAudio();
    }

    public void ResumeGame()
    {
        isPause = false;
        pauseButtonPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
        //Revert audio change
        PauseSnapshot.Instance.StopPauseAudio();
    }
    public void RestartLevel() {
        Time.timeScale = 1;
        fadeSystem.FadeOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMainMenu()
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