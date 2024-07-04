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
   public List<TUTORIAL_KEY> tutKeys;
   private int tutorialIndex = 0;
   //1. move
   //2. when player moves, show second 
   //3. when player interacts with light, show rotate light
   //4. when player does that, show match light sourve
   private float FADE_TIME = 3.0f;

   void Start()
   {
      HideAllText();
      OnNextTutorialStep(TUTORIAL_KEY.NONE);
   }
   private void HideAllText()
   {
      foreach (var text in tutorialTexts)
      {
         text.gameObject.SetActive(false);
      }
   }

   public void TutorialSubscribeEvent(UnityEvent _event, int tutorialOrder )
   {
      
   }
   
   [ProButton]
   public void OnNextTutorialStep(TUTORIAL_KEY currentTutorialKey)
   {
      if (tutorialIndex >= tutorialTexts.Count)
         return;
      if (tutKeys[tutorialIndex] != currentTutorialKey)
         return;
      
      StartCoroutine(FadeInText(tutorialTexts[tutorialIndex]));
      tutorialIndex++;
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

   public bool Requires(TUTORIAL_KEY tutKey)
   {
      return tutKeys.Contains(tutKey);
   }

   [ProButton]
   private void Debug_FadeInAllText()
   {
      foreach (var text in tutorialTexts)
      {
         StartCoroutine(FadeInText(text));
      }
   }

   public void InsertEvent(UnityEvent<TUTORIAL_KEY> _evt)
   {
     _evt.AddListener(OnNextTutorialStep);
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