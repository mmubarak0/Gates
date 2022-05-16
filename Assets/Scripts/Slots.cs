using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler
{
    public static bool dropped = false;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Droped");
        if (eventData.pointerDrag != null) {
            dropped = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
