using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using UnityEngine.Events;

public class UIFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
     private float fadeDuration = 2.0f;

    public UnityEvent OnFadeOutComplete;
    public UnityEvent OnFadeInComplete;
    public UnityEvent OnFadeOutCompleteGameOvxer;
    private void Start()
    {
        FadeIn();
    }

    [ProButton]
    public void FadeIn()
    {
        canvasGroup.alpha = 1f;
        StartCoroutine(FadeCanvasGroup( canvasGroup.alpha, 0, fadeDuration, true));
    }

    [ProButton]
    public void FadeOut(bool isFromGameover = false)
    {
        StartCoroutine(FadeCanvasGroup( canvasGroup.alpha, 1f, fadeDuration, false, isFromGameover));
    }

    private IEnumerator FadeCanvasGroup( float start, float end, float duration, bool isFadein, bool isFromGameover = false)
    {



        float elaspedTime = 0.0f;
        while(elaspedTime < duration)
        {
            elaspedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elaspedTime / duration);
            yield return null;
        }
        canvasGroup.alpha = end;
     
        if (isFadein)
            OnFadeInComplete?.Invoke();
        else
        {
            if (!isFromGameover)
            {
                Debug.Log("not from game over");
                OnFadeOutComplete?.Invoke();

            }
            else
            {
                OnFadeOutCompleteGameOvxer?.Invoke();
            }
            
        }
    }



}


