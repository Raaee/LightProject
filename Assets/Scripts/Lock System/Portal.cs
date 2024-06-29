
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Portal : MonoBehaviour
{
    private Door door;
     [HideInInspector] public UnityEvent OnPlayerEntersPortal;
     [SerializeField] private bool isGameplayLevel = false;
     private float waitTime = 1.5f;
     
    private void Awake()
    {
        door = GetComponent<Door>();
        if(isGameplayLevel)
            Debug.LogWarning("This portal configs marks this scene as a gameplay scene." +
                             " When player goes to portal it will increase currentLevel progress");
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
            StartCoroutine(WaitThenLoadScene(waitTime));
        }
        else
        {
            //show pause menu 
            Debug.Log("This is a sandbox level. Still figuring out what to do. for now go to pause menu and go back to menu");
        }
        
        //play teleport animation 
    }

    private IEnumerator WaitThenLoadScene(float time)
    {
        Debug.Log("Going to Next Level...321");
        yield return new WaitForSeconds(time);
        int index = ES3.Load(Utility.CURRENT_LEVEL_KEY, 0);
        SceneManager.LoadScene(LevelSelectDataHandler.Instance.gamePlayLevelElements[index].scenePath);
    }
}
