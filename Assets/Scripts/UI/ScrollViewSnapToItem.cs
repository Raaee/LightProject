using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollViewSnapToItem : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private RectTransform sampleListItem;

    [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
    [SerializeField] private float VELOCITY_LIMIT = 200f;
    [SerializeField] private float VELOCITY_TOLERANCE = 0.1f; 
    private bool isSnapping;
    private int currentItem = 0;

    private void Start()
    {
        StartCoroutine(SnapToTargetItem());
    }

    public void OnNextButtonPress()
    {
        Debug.Log("Movin up");
        currentItem++;
        StartCoroutine(SnapToTargetItem());
        // contentPanel.localPosition = new Vector3( 0 -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)),contentPanel.localPosition.y, contentPanel.localPosition.z);
    }

    private IEnumerator SnapToTargetItem()
    {
        isSnapping = true;
        while (Mathf.Abs(scrollRect.content.localPosition.x - GetTargetPosition()) > VELOCITY_TOLERANCE)
        {
            float targetX = Mathf.Lerp(scrollRect.content.localPosition.x, GetTargetPosition(), Time.deltaTime * 10f); // Smoother snapping with lerp
            scrollRect.content.localPosition = new Vector3(targetX, scrollRect.content.localPosition.y, scrollRect.content.localPosition.z);
            yield return null;
        }
    }
    private float GetTargetPosition()
    {
        return -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing));
    }
}
