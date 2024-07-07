using System;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference acceptSfx;
    [SerializeField] private FMODUnity.EventReference backSfx;
    [SerializeField] private FMODUnity.EventReference selectNextSfx;
    [SerializeField] private FMODUnity.EventReference startPauseSfx;
    [SerializeField] private FMODUnity.EventReference exitPauseSfx;
    [SerializeField] private FMODUnity.EventReference hoverSfx;
    [SerializeField] private FMODUnity.EventReference testSfx;

    public void PlayUIAudio(int audioEnum)
    {
        switch (audioEnum)
        {
            case (int)UIAudioEnum.NONE:
                FMODUnity.RuntimeManager.PlayOneShot(testSfx);
                break;
            case  (int)UIAudioEnum.Accept:
                FMODUnity.RuntimeManager.PlayOneShot(acceptSfx);
                break;
            case  (int)UIAudioEnum.Back:
                FMODUnity.RuntimeManager.PlayOneShot(backSfx);
                break;
            case  (int)UIAudioEnum.Select_Next:
                FMODUnity.RuntimeManager.PlayOneShot(selectNextSfx);
                break;
            case  (int)UIAudioEnum.Start_Pause:
                FMODUnity.RuntimeManager.PlayOneShot(startPauseSfx);
                break;
            case  (int)UIAudioEnum.Exit_Pause:
                FMODUnity.RuntimeManager.PlayOneShot(exitPauseSfx);
                break;
            case  (int)UIAudioEnum.Hover:
                FMODUnity.RuntimeManager.PlayOneShot(hoverSfx);
                break;
            default:
                Debug.Log("bruh what is this sound effect");
                break;
        }
    }
}

public enum UIAudioEnum
{
    NONE,
    Accept,
    Back,
    Select_Next,
    Start_Pause,
    Exit_Pause,
    Hover
}