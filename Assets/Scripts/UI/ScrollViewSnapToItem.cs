using System.Collections;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;


public class ScrollViewSnapToItem : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private LevelSelectView levelSelectView;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private RectTransform sampleListItem;
    [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
    private const float VELOCITY_TOLERANCE = 0.1f; 
   
    private int currentItem = 0;
    private int previousItem = 0;
   // [SerializeField] private LevelSelectController levelSelectCont;
    private int totalItems = 0;
    [Header("Audio")] 
    [SerializeField] private EventReference forwardSfx;
    [SerializeField] private EventReference backSfx;
    
    private void Start()
    {
        totalItems = LevelSelectDataHandler.Instance.sandboxLevelElements.Count;
        StartCoroutine(SnapToTargetItem());
    }

    public void OnNextButtonPress()
    {
        previousItem = currentItem;
        currentItem++;
        currentItem = currentItem > (totalItems - 1) ? (totalItems - 1) : currentItem;
        StartCoroutine(SnapToTargetItem());
        FMODUnity.RuntimeManager.PlayOneShot(forwardSfx);
        // contentPanel.localPosition = new Vector3( 0 -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)),contentPanel.localPosition.y, contentPanel.localPosition.z);
    }
    
    public void OnBackButtonPress()
    {
        previousItem = currentItem;
        currentItem--;
        currentItem = currentItem < 0 ? 0 : currentItem;
        StartCoroutine(SnapToTargetItem());
        FMODUnity.RuntimeManager.PlayOneShot(backSfx);

        // contentPanel.localPosition = new Vector3( 0 -(currentItem * (sampleListItem.rect.width + horizontalLayoutGroup.spacing)),contentPanel.localPosition.y, contentPanel.localPosition.z);
    }

    private IEnumerator SnapToTargetItem()
    {
        levelSelectView.HighlightSelectedCard(previousItem, currentItem);
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
