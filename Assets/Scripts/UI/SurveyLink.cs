using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveyLink : MonoBehaviour
{
    [SerializeField] private List<string> surveyUrl;
    [SerializeField] private string realUrl;
   public void OpenUrl()
    {
        Application.OpenURL(realUrl);
    }
}
