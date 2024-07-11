
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ResetProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resetText;
    [SerializeField] private TextMeshProUGUI resetButtonText;
    private const string WARNING_TEXT = "This will reset all your gameplay progress. Click again to confirm.";
    private const string CONFIRM_TEXT = "Gameplay progress is now reset!";
    private const string BUTTON_STANDARD_TEXT = "Reset Progress";
    private const string BUTTON_WARNING_TEXT = "Confirm?";

    private RESET_PROGRESS_STATE currentState = RESET_PROGRESS_STATE.IDLE;

    private void Start()
    {
        HandleIdle();
    }

    public void OnResetButtonPressed()
    {
        switch (currentState)
        {
            case RESET_PROGRESS_STATE.IDLE:
                HandleConfirming();
                break;
            case RESET_PROGRESS_STATE.CONFIRMING:
                HandleAccepted();
                break;
            case RESET_PROGRESS_STATE.ACCEPTED:
                //do nothing
                break;
            default:
                break;
        }
    }

    public void HandleIdle()        //called in start or when player presses back button 
    {
        currentState = RESET_PROGRESS_STATE.IDLE;
        resetText.gameObject.SetActive(false);
        resetButtonText.text = BUTTON_STANDARD_TEXT;
    }
    private void HandleAccepted()
    {
        currentState = RESET_PROGRESS_STATE.ACCEPTED;
        OnResetProgress();
        resetText.text = CONFIRM_TEXT;
        resetButtonText.text = "";
    }

    private void HandleConfirming()
    {
        currentState = RESET_PROGRESS_STATE.CONFIRMING;
        resetText.text = WARNING_TEXT;
        resetText.gameObject.SetActive(true);
        resetButtonText.text = BUTTON_WARNING_TEXT;
    }

    private void OnResetProgress()
    {
        ES3.Save(Utility.CURRENT_LEVEL_KEY, 0);
    }
}

public enum RESET_PROGRESS_STATE
{
    IDLE,
    CONFIRMING,
    ACCEPTED
}