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
    private bool isSnapped;
    
    private void Update()
    {
        int currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x / (sampleListItem.rect.width + horizontalLayoutGroup.spacing)));
        Debug.Log(currentItem);

        if (scrollRect.velocity.magnitude < VELOCITY_LIMIT)
        {
            contentPanel.localPosition = new Vector3( 0 -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)),contentPanel.localPosition.y, contentPanel.localPosition.z);
            isSnapped = true;
        }

        if (scrollRect.velocity.magnitude < VELOCITY_LIMIT)
        {
            isSnapped = false;
        }
    }
}
