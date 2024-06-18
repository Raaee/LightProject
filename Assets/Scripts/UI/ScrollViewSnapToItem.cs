using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ScrollViewSnapToItem : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private RectTransform sampleListItem;

    [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
   
     private const float VELOCITY_TOLERANCE = 0.1f; 
   
    private int currentItem = 0;
    [SerializeField] private LevelSelectController levelSelectCont;
    private int totalItems = 0; 
    
    private void Start()
    {
        totalItems = levelSelectCont.levelElements.Count;
        StartCoroutine(SnapToTargetItem());
    }

    public void OnNextButtonPress()
    {
        currentItem++;
        currentItem = currentItem > (totalItems - 1) ? (totalItems - 1) : currentItem;
        StartCoroutine(SnapToTargetItem());
        // contentPanel.localPosition = new Vector3( 0 -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)),contentPanel.localPosition.y, contentPanel.localPosition.z);
    }
    
    public void OnBackButtonPress()
    {
        currentItem--;
        currentItem = currentItem < 0 ? 0 : currentItem;
        StartCoroutine(SnapToTargetItem());
        // contentPanel.localPosition = new Vector3( 0 -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)),contentPanel.localPosition.y, contentPanel.localPosition.z);
    }

    private IEnumerator SnapToTargetItem()
    {
        while (Mathf.Abs(scrollRect.content.localPosition.x - GetTargetPosition()) > VELOCITY_TOLERANCE)
        {
            float targetX = Mathf.Lerp(scrollRect.content.localPosition.x, GetTargetPosition(), Time.deltaTime * 10f); 
            scrollRect.content.localPosition = new Vector3(targetX, scrollRect.content.localPosition.y, scrollRect.content.localPosition.z);
            yield return null;
        }
    }
    private float GetTargetPosition()
    {
        return -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing));
    }

    public int GetCurrentItem() => currentItem;
  
}
