using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomScrollRect : ScrollRect
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin dragging ");}
    public override void OnDrag(PointerEventData eventData) {Debug.Log("on dragging "); }
    public override void OnEndDrag(PointerEventData eventData) {Debug.Log("end dragging "); }
}
