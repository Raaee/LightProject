using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoreTextUI : MonoBehaviour
{
   private TextMeshProUGUI loreText;
   private const float FADE_TIME = 3f;
   private void Awake()
   {
      loreText = GetComponent<TextMeshProUGUI>();
      if (loreText == null)
      {
         //there should be a text ui thing 
         Debug.Log("there should be a text ui thing in this gameobject");
      }
   }

   private void Start()
   {
      StartCoroutine(FadeInText());
      loreText.text = Utility.LoreUtility(loreText.text);
   }
   
   private IEnumerator FadeInText()
   {
      CanvasGroup canvasGroup = loreText.gameObject.GetComponent<CanvasGroup>();
      canvasGroup.alpha = 0;
      
      float elapsedTime = 0.0f;
      while(elapsedTime < FADE_TIME)
      {
         elapsedTime += Time.deltaTime;
         canvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / FADE_TIME);
         yield return null;
      }
      canvasGroup.alpha = 1.0f;

   }
}
