using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyLink : MonoBehaviour
{
    [SerializeField] private List<string> surveyUrl;
   public void OpenUrl()
    {
        Application.OpenURL(surveyUrl[Random.Range(0, surveyUrl.Count)]);
    }
}
