using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotForPlayer : ASlot
{
    protected override void CardChangePosition(PointerEventData eventData)
    {
        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        GameObject card = eventData.pointerDrag;
        if (cardDragged.originalContainerSlot.GetComponent<AContainsSlots>().ContainsSlot(transform.parent.parent))
        {
            if (cardDragged.originalParent.GetComponent<SlotForPlayer>() != null)
            {
                if (transform.childCount > 0)
                {
                    SwapCard(card);
                }
                else
                {
                    CardGoesOn(card);
                }
            }

            if (transform.childCount == 0)
            {
                CardGoesOn(card);
            }
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<CardDragHandler>().originalContainerSlot = transform.parent.parent;
    }
    

    public override void RepairdCard(CardDragHandler cardDragged)
    {
        cardDragged.transform.SetParent(cardDragged.originalParent.transform);
        cardDragged.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public override void DestroyCard(PointerEventData eventData)
    {
        Debug.Log("SlotForPlayer cannot destroy Card");
    }
}
