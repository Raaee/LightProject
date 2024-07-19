using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorMenu : MonoBehaviour
{
    public void BackToMainMenuFromLS() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu_");
    }
    public void ToLevelSelector() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level Selector");
    }
}
