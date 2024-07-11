
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Portal : MonoBehaviour
{
    private Door door;
     [HideInInspector] public UnityEvent OnPlayerEntersPortal;
      private bool isGameplayLevel = true;
     private float waitTime = 2.0f;
     
    private void Awake()
    {
        door = GetComponent<Door>();
        DetermineIfGameplayLevel();
        
    }

  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement potentialPlayer = collision.gameObject.GetComponent<PlayerMovement>();
        if (potentialPlayer == null) return;
        if (door.IsLocked == true) return;
        
        potentialPlayer.FreezePlayer();
        GoToNextLevel();
        OnPlayerEntersPortal?.Invoke();

    }

    private void GoToNextLevel()
    {
        if (isGameplayLevel)
        {
            SaveManager.Instance.OnNextLevelProgressed();
            Debug.Log("Starting Couroutine to wait then load scene");
            StartCoroutine(WaitThenLoadScene(waitTime));
        }
        else
        {
            var pauseMenu = FindObjectOfType<PauseSystem>();
            if (pauseMenu == null)
            {
                Debug.LogError("Theres no pause prefab in this scene!");

                return;
            } 
            pauseMenu.PauseGame();
            
        }
        Debug.Log("Attempting to stop audio atmospher");

        LevelManager.Instance.StopAudioAtmosphere();
        //play teleport animation 
    }

    private IEnumerator WaitThenLoadScene(float time)
    {
        
        Debug.Log("Going to Next Level...321");
        yield return new WaitForSeconds(time);
        int index = ES3.Load(Utility.CURRENT_LEVEL_KEY, 0);
        SceneManager.LoadScene(LevelSelectDataHandler.Instance.gamePlayLevelElements[index].scenePath);
    }
    
    private void DetermineIfGameplayLevel()
    {
        var pathOfThisScene = SceneManager.GetActiveScene().path;
        if (LevelSelectDataHandler.Instance.gamePlayLevelElements.Count == 0)
        {
            Debug.Log("Did not start this scene from the main menu");
            return;
        }

        foreach (var item in LevelSelectDataHandler.Instance.sandboxLevelElements)
        {
            if (item.scenePath == pathOfThisScene)
            {
                isGameplayLevel = false;
                Debug.LogWarning("This is a SANDBOX SCENE" +
                                 " When player goes to portal it will show pause menu");
            }
            
        }
        
        foreach (var item in LevelSelectDataHandler.Instance.gamePlayLevelElements)
        {
            if (item.scenePath == pathOfThisScene)
            {
                Debug.LogWarning("This is a GAMEPLAY SCENE" +
                                 " When player goes to portal it will increase currentLevel progress");
            }
            
        }
     
      
    }
}
