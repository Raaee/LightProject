using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] private GameObject panelGO;


    public static NextLevelUI Instance { get; set; }

    private UIFade uiFade;
    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one NEXT LEVEL UI in scene");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        HidePanel();
        uiFade = GetComponentInChildren<UIFade>();
        uiFade.OnFadeOutComplete.AddListener(OnFadeUIFinished);
    }
    public void ShowPanel()
    {
        panelGO.SetActive(true);
    }

    public void HidePanel()
    {
        panelGO.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartTransitionToNextLevel()
    {
        uiFade.FadeOut();
    }
    private void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnFadeUIFinished()
    {
        GoToNextLevel();
    }
}
