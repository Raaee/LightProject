using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NextLevelUI : MonoBehaviour
{
    [SerializeField] private GameObject panelGo;
    public static NextLevelUI Instance { get; set; }

    private UIFade uiFade;

    private bool alreadyClicked = false;
    
    public UnityEvent OnStartTransitionFadeOut;
    
    [SerializeField] private FMODUnity.EventReference genericUISound;
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
        panelGo.SetActive(true);
    }

    public void HidePanel()
    {
        panelGo.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartTransitionToNextLevel()
    {
        if (alreadyClicked)
            return;
            
        uiFade.FadeOut();
        alreadyClicked = true;
        OnStartTransitionFadeOut?.Invoke();
        RuntimeManager.PlayOneShot(genericUISound, transform.position);
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
