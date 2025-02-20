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
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    public virtual void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        originalContainerSlot = GetComponentInParent<IContainsSlots>().transform;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalParent.GetComponent<ASlot>().GetSlot();
        originalParent.GetComponent<ASlot>().OnBeginDrag(eventData); //Delegation for slot
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (transform.parent == originalParent || cardDragged.transform.parent.GetComponent<ASlot>() == null)
        {
            cardDragged.transform.SetParent(originalParent);
            cardDragged.transform.parent.GetComponent<ASlot>().RepairdCard(cardDragged);
        }
    }
}
