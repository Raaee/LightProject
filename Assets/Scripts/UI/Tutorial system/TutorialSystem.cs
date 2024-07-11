using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class TutorialSystem : MonoBehaviour
{
   public List<TextMeshProUGUI> tutorialTexts; //each tmp should have a canvas group on it 
  
   public int TutorialIndex { get; private set; }

   //1. move
   //2. when player moves, show second 
   //3. when player interacts with light, show rotate light
   //4. when player does that, show match light sourve
   private float FADE_TIME = 5.0f;

   void Start()
   {
      TutorialIndex = 0;
      HideAllText();
      OnNextTutorialStep(0);
   }
   private void HideAllText()
   {
      foreach (var text in tutorialTexts)
      {
         text.gameObject.SetActive(false);
      }
   }

 
   
   [ProButton]
   public void OnNextTutorialStep( int currentOrder)
   {
      if (TutorialIndex >= tutorialTexts.Count)
         return;
      if (currentOrder != TutorialIndex)
         return;

      StartCoroutine(FadeInText(tutorialTexts[TutorialIndex]));
      TutorialIndex++;

   }

   private IEnumerator FadeInText(TextMeshProUGUI text)
   {
      text.gameObject.SetActive(true);
      
      var canvasGroup = text.gameObject.GetComponent<CanvasGroup>();
      canvasGroup.alpha = 0;
      
      float elaspedTime = 0.0f;
      while(elaspedTime < FADE_TIME)
      {
         elaspedTime += Time.deltaTime;
         canvasGroup.alpha = Mathf.Lerp(0, 1, elaspedTime / FADE_TIME);
         yield return null;
      }
      canvasGroup.alpha = 1.0f;

   }

 

   [ProButton]
   private void Debug_FadeInAllText()
   {
      foreach (var text in tutorialTexts)
      {
         StartCoroutine(FadeInText(text));
      }
   }

 
}

public enum TUTORIAL_KEY
{
   NONE,
   MOVE,
   INTERACT_WITH_LIGHT,
   INTERACT_WITH_MIRROR,
   MATCH_LIGHT_SRC,
   PUSH_CHAINED_MIRRORS,
   DOOR_BLOCK_WAY
}