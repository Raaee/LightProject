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

    public void PlayUIAudio(UIAudioEnum audioEnum)
    {
        switch (audioEnum)
        {
            case UIAudioEnum.NONE:
                FMODUnity.RuntimeManager.PlayOneShot(testSfx);
                break;
            case UIAudioEnum.Accept:
                FMODUnity.RuntimeManager.PlayOneShot(acceptSfx);
                break;
            case UIAudioEnum.Back:
                FMODUnity.RuntimeManager.PlayOneShot(backSfx);
                break;
            case UIAudioEnum.Select_Next:
                FMODUnity.RuntimeManager.PlayOneShot(selectNextSfx);
                break;
            case UIAudioEnum.Start_Pause:
                FMODUnity.RuntimeManager.PlayOneShot(startPauseSfx);
                break;
            case UIAudioEnum.Exit_Pause:
                FMODUnity.RuntimeManager.PlayOneShot(exitPauseSfx);
                break;
            case UIAudioEnum.Hover:
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