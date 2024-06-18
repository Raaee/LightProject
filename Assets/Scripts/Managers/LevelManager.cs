using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] enemiesInLevel;
    private const string ENEMY_TAG = "Enemy";

    void Start() {
        enemiesInLevel = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
        foreach (GameObject enemy in enemiesInLevel) {
            enemy.GetComponentInChildren<Detection>().OnDetectedGameOver.AddListener(GameOver);
        }
    }
    public void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Damn sucks. Get gud");
    }
}
