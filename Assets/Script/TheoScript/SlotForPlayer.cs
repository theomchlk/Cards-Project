using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotForPlayer : ASlot
{
    protected override void CardChangePosition(GameObject card)
    {
        CardDragHandler cardDragged = card.GetComponent<CardDragHandler>();
        if (cardDragged.originalContainerSlot.GetComponent<IContainsSlots>().ContainsSlot(transform.parent.parent))
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
        
    }

    public override void RepairdCard(CardDragHandler cardDragged)
    {
        cardDragged.transform.SetParent(cardDragged.originalParent.transform);
        cardDragged.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
