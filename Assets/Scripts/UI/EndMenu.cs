using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Image centerImage;
    [SerializeField] private Animator centerImageAnimator;
    [SerializeField] private AnimationClip colorChange;
    private float centerImageStartingScale = 2f;
    
    private void Start() {
        StartCoroutine(EndAnimation());
    }
    private IEnumerator EndAnimation() {
        float elapsedTime = 0.0f;
        float animationTime = 1f;
        float targetScale = 0f;
        centerImage.transform.localScale = new Vector3(centerImageStartingScale, centerImageStartingScale, centerImageStartingScale);
        centerImageAnimator.Play(colorChange.name);
        while (elapsedTime < animationTime) {
            // Calculate the lerp value based on elapsed time
            float lerpValue = elapsedTime / animationTime;

            // Use Vector3.Lerp for smooth scaling
            centerImage.transform.localScale = Vector3.Lerp(new Vector3(centerImageStartingScale, centerImageStartingScale, centerImageStartingScale),
                new Vector3(0.01f, 0.01f, 0.01f), lerpValue);

            // Wait for the next frame to update the scale
            yield return new WaitForEndOfFrame();

            // Update elapsed time
            elapsedTime += Time.deltaTime;
        }
        centerImage.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
    }
}
