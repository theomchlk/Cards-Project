using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class SlotForPlayer : ACardSlot
{
    public Tuple<int, int> position;
    public void Awake()
    {
        container = transform.parent.parent.GetComponent<AContainsSlots>();
    }

    protected override void CardChangePosition(PointerEventData eventData)
    {
        
        
        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        GameObject card = eventData.pointerDrag;
        CardLogic cardLogic = card.GetComponent<CardLogic>();
        if (container.ContainsSlot(cardDragged.originalContainerSlot))
        {
            if (cardDragged.originalParent.GetComponent<SlotForPlayer>() != null)
            {
                SlotForPlayer originalSlotForPlayer = cardDragged.originalParent.GetComponent<SlotForPlayer>();
                
                if (transform.childCount > 0)
                { 
                    container.GetComponent<Player>().slotWithCard[originalSlotForPlayer.position] = cardLogic;

                    SwapCard(card);
                }
                else
                {
                    CardGoesOn(card);
                }
                container.GetComponent<Player>().slotWithCard[position] = cardLogic;
            }

            else if (transform.childCount == 0) //if there is no card on the slot
            {
                container.GetComponent<Player>().slotWithCard[position] = cardLogic;
                CardGoesOn(card);
            }
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        container.GetComponent<Player>().slotWithCard.Remove(position);
        eventData.pointerDrag.GetComponent<CardDragHandler>().originalContainerSlot = container.transform;
        
    }
    

    public override void RepairdCard(CardDragHandler cardDragged)
    {
        container.GetComponent<Player>().slotWithCard[position] = cardDragged.GetComponent<CardLogic>();
        cardDragged.transform.SetParent(cardDragged.originalParent.transform);
        cardDragged.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public override void DestroyCard(PointerEventData eventData)
    {
        Debug.Log("SlotForPlayer cannot destroy Card");
    }
    
    
}
