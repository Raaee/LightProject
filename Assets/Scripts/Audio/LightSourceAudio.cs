using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceAudio : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private FMODUnity.EventReference turnOnLightSource;
    [SerializeField] private FMODUnity.EventReference turnOffLightSource;
    
    [SerializeField] private FMODUnity.EventReference idleLightSource;


    [Header("References")]
       private const string LIGHT_BEAMS_PARAM = "LightBeamsTurnedOn";
    private List<LightSource> allLightSourcesInScene;

    private ExtendedAudioContainer idleLightSourceAudioContainer = new ExtendedAudioContainer();

    private void Start()
    {
        allLightSourcesInScene = new List<LightSource>();
        FindLightSourcesInScene();

       
        idleLightSourceAudioContainer.InitAudio(idleLightSource);
        //idleLightSourceAudioContainer.ConnectTo3DAudio(lightSourceTransform, lightSourceRb2d);
        idleLightSourceAudioContainer.SetParameter(LIGHT_BEAMS_PARAM, 0);
    }

    private void FindLightSourcesInScene()
    {
        var lightSources = FindObjectsOfType<LightSource>();
        foreach(var ls in lightSources)
        {
            allLightSourcesInScene.Add(ls);
            ls.OnLightSourceInteracted.AddListener(UpdateLightSourceAudioSystem);
        }
        Debug.Log("There are " + allLightSourcesInScene.Count + " in this scene");
    }

    private void UpdateLightSourceAudioSystem()
    {
        int amtOfLightSourcesTurnedOn = 0;
        foreach(var ls in allLightSourcesInScene)
        {
            if (ls.LightSourceIsOn)
                amtOfLightSourcesTurnedOn++;
        }
        float percentageOfLightsOn = (float)amtOfLightSourcesTurnedOn / allLightSourcesInScene.Count;
        Debug.Log("percentage is now " + percentageOfLightsOn);
       idleLightSourceAudioContainer.SetParameter(LIGHT_BEAMS_PARAM, percentageOfLightsOn);
    }

    private void PlayTurnOnLSAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(turnOnLightSource, transform.position);
    }

    private void PlayTurnOffLSAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(turnOffLightSource, transform.position);
    }

  

   

}
