using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject player;
    private UIFade uiFade;
    private const string ENEMY_TAG = "Enemy";

    public GameObject[] enemiesInLevel;

    private void Awake() {
        uiFade = FindObjectOfType<UIFade>();    
        Debug.Log(SceneManager.GetActiveScene().path);
    }
    void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        enemiesInLevel = GameObject.FindGameObjectsWithTag(ENEMY_TAG);
        foreach (GameObject enemy in enemiesInLevel) {
            enemy.GetComponentInChildren<Detection>().OnDetectedGameOver.AddListener(GameOver);
        }
        uiFade.OnFadeOutCompleteGameOvxer.AddListener(RestartScene);
    }
    [ProButton]
    public void GameOver() {
        player.GetComponent<InputControls>().DisableControls();
        uiFade.FadeOut(true);
        StopAudioAtmosphere();
    }

  

    private void RestartScene() {
        Debug.Log(SceneManager.GetActiveScene().path);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void StopAudioAtmosphere()
    {
        var audioAtmosGameobject = FindObjectOfType<PauseSnapshot>().gameObject;
        audioAtmosGameobject.GetComponentInChildren<GameplayMusicSysten>()?.StopCurrentSong();
        audioAtmosGameobject.GetComponentInChildren<AmbienceAudio>()?.StopAmbienceAudioSystem();
        audioAtmosGameobject.GetComponentInChildren<LightSourceAudio>()?.StopIdleLigthSrc();
    }
}
