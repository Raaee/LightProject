using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InteractVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactMessageText;
    [SerializeField] private string PROMPT_MESSAGE = "E/M2 To Interact"; // Message that displays when in range of an interactable
    [SerializeField] [Range(1.0f, 2.0f)] private float playerRangeDistance = 1.625f;
    private Transform playerTransform; 

    void Start()
    {
        DisablePromptMessage();
        playerTransform = FindObjectOfType<PlayerMovement>().gameObject.transform;
        if (playerTransform == null)
            Debug.Log("No player obj with PlayerMovement Obj in scene");
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
         if (distanceToPlayer < playerRangeDistance)
            EnablePromptMessage();
         else
           DisablePromptMessage();
    }
    private void EnablePromptMessage()
    {
        interactMessageText.text = PROMPT_MESSAGE;
    }

    private void DisablePromptMessage()
    {
        interactMessageText.text = " ";
    }
}
