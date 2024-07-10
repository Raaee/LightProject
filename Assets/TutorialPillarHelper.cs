using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPillarHelper : MonoBehaviour
{
   public List<Pillar> pillars;
   [SerializeField] private LightSource lightSource;

   private TutorialSystem tutorialSystem;
   private void Start()
   {
      tutorialSystem = GetComponent<TutorialSystem>();
      foreach (var pill in pillars)
      {
         pill.OnPillarRotate.AddListener(OnFirstPillarRotate);
      }
      
      lightSource.OnLightSourceInteracted.AddListener(OnFirstLightSourceInteracted);
   }

   private void OnFirstLightSourceInteracted()
   {
      if(tutorialSystem.TutorialIndex != 2)
         return;

      tutorialSystem.OnNextTutorialStep(2);
   }

   private void OnFirstPillarRotate()//if any of the pillars rotate
   {
      //and we are on current order 3
      if(tutorialSystem.TutorialIndex != 3)
         return;
      
      //we go to the next tutorial text
      tutorialSystem.OnNextTutorialStep(3);
      
   }
}
