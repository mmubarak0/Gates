using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    private RectTransform rectTrans;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    private Vector2 initPosition;

    void Start() {
        myCanvas = FindObjectOfType<Canvas>();
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("EndDrag");
        canvasGroup.blocksRaycasts = true;
        if (Slots.dropped != true){
            resetPosition();
            Slots.dropped = false;
        } else {
            Slots.dropped = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("CLICK");
    }

    public void resetPosition()
    {
        transform.position = initPosition;
    }
}
