using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 2.5f;

    public UnityEvent OnFadeOutComplete;
    public UnityEvent OnFadeInComplete;
    private void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        canvasGroup.alpha = 1f;
        StartCoroutine(FadeCanvasGroup( canvasGroup.alpha, 0, fadeDuration, true));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup( canvasGroup.alpha, 1f, fadeDuration, false));
    }

    private IEnumerator FadeCanvasGroup( float start, float end, float duration, bool isFadein)
    {



        float elaspedTime = 0.0f;
        while(elaspedTime < fadeDuration)
        {
            elaspedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elaspedTime / duration);
            yield return null;
        }
        canvasGroup.alpha = end;
     
        if (isFadein)
            OnFadeInComplete?.Invoke();
        else
            OnFadeOutComplete?.Invoke();
    }



}
