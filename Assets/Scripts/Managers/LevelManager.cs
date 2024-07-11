using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private GameObject player;
    private UIFade uiFade;
    private const string ENEMY_TAG = "Enemy";

    public GameObject[] enemiesInLevel;

    protected override void Awake() {
        base.Awake();
        uiFade = FindObjectOfType<UIFade>();
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
    
    public void StopAudioAtmosphere()
    {
        Debug.Log(" stoppin everythomg");
        var audioAtmosGameobject = FindObjectOfType<PauseSnapshot>().gameObject;
        audioAtmosGameobject.GetComponentInChildren<GameplayMusicSysten>()?.StopCurrentSong();
        audioAtmosGameobject.GetComponentInChildren<AmbienceAudio>()?.StopAmbienceAudioSystem();
        audioAtmosGameobject.GetComponentInChildren<LightSourceAudio>()?.StopIdleLigthSrc();
       var pa = FindObjectOfType<PortalAudio>();
       if (pa)
       {
           pa.ForceStopPortalAudio();
       }
       else
       {
           Debug.Log("PA is null we cant stop the audio");
       }
    }

    
}
