using System;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    public Transform originalParent;
    public Transform originalContainerSlot;
    public Transform originalParentInRememberingTypeSlot; //slot who need remember the card
    public bool canBeDragged = true;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    public virtual void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalParent.GetComponent<ACardSlot>().OnBeginDrag(eventData); //Delegation for slot
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canBeDragged)
        {
            Vector2 localPoint;
    

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint
            );


            rectTransform.anchoredPosition = localPoint;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (transform.parent == originalParent || !cardDragged.canBeDragged || eventData.pointerDrag.transform.parent.GetComponent<ACardSlot>() == null)
        {
            eventData.pointerDrag.transform.SetParent(originalParent); //obligatoire pour faire le Repair selon le slot parent
            Debug.Log(canBeDragged);
            Debug.Log(eventData.pointerDrag.transform.parent.GetComponent<ACardSlot>() == null);
            eventData.pointerDrag.transform.parent.GetComponent<ACardSlot>().RepairdCard(cardDragged);
        }
    }
    
}