using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject player;
    public UIFade uiFade;
    private const string ENEMY_TAG = "Enemy";

    public GameObject[] enemiesInLevel;

    private void Awake() {
        uiFade = FindObjectOfType<UIFade>();        
    }
    void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        enemiesInLevel = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
        foreach (GameObject enemy in enemiesInLevel) {
            enemy.GetComponentInChildren<Detection>().OnDetectedGameOver.AddListener(GameOver);
        }
        uiFade.OnFadeOutComplete.AddListener(RestartScene);
    }
    [ProButton]
    public void GameOver() {
        player.GetComponent<InputControls>().DisableControls();
        uiFade.FadeOut();
    }
    private void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Damn sucks. Get gud");
    }
}
