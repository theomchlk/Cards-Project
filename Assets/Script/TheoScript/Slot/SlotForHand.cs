using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotForHand : ACardSlot
{
    public bool occupied = false;

    public void Awake()
    {
        container = transform.parent.GetComponent<AContainsSlots>();
    }

    protected override void CardChangePosition(PointerEventData eventData)
    {
        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (cardDragged.canBeDragged)
        {
            if (container.ContainsSlot(cardDragged.originalContainerSlot))
            {
                if (cardDragged.originalParent.GetComponent<SlotForHand>() != null)
                {
                    if (occupied == false)
                    {
                        cardDragged.originalParent.GetComponent<SlotForHand>().occupied = false;
                        CardGoesOn(eventData.pointerDrag);
                        occupied = true;
                    }

                    cardDragged.originalParent.GetComponent<CanvasGroup>().alpha = 1;
                }
                else
                {
                    if (cardDragged.originalParentInRememberingTypeSlot != null)
                    {
                        RepairdCard(cardDragged);
                    }
                    else
                    {
                        if (occupied == false)
                        {
                            CardGoesOn(eventData.pointerDrag);
                            occupied = true;
                        }
                    }
                }
            }
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {

        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        cardDragged.originalContainerSlot = transform.parent;
        if (cardDragged.originalParentInRememberingTypeSlot != transform)
        {
            cardDragged.originalParentInRememberingTypeSlot = transform;
            transform.GetComponent<Image>().sprite = cardDragged.GetComponent<Image>().sprite;
        }

        transform.GetComponent<CanvasGroup>().alpha = 0.5f;
    }

    public override void RepairdCard(CardDragHandler cardDragged)
    {

        cardDragged.originalParentInRememberingTypeSlot.GetComponent<CanvasGroup>().alpha = 1;
        cardDragged.transform.SetParent(cardDragged.originalParentInRememberingTypeSlot.transform);
        cardDragged.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

    }

    public override void DestroyCard(PointerEventData eventData)
    {
        occupied = false;
        transform.GetComponent<CanvasGroup>().alpha = 1;
        Destroy(eventData.pointerDrag);
    }


    public override void GetSlot()
    {
        Debug.Log("GetSlotHand");
    }

}
/*
    public override void OnEndDrag(PointerEventData eventData)
    {
        //doit gerer si ca  ne fonctionne pas
        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (transform.parent.GetComponent<IContainsSlots>(). .originalContainerSlot)
        if (cardDragged.originalParentInRemberingTypeSlot != transform)
        {
            cardDragged.originalParentInRemberingTypeSlot = transform;
            transform.GetComponent<Image>().sprite = cardDragged.GetComponent<Image>().sprite;

        }
        transform.GetComponent<CanvasGroup>().alpha = 1f;
    }


}
*/

/*
public abstract class Slot : MonoBehavior
{
    public virtual void Fonc1(){
        //Implementation
    }
}

public class SlotPlayer : Slot
{                                        
    public void Fonc1(){         
        //Implementation                 
    }    
    
    public void Fonc2(){
        Debug.Log("Fonction 2 de SlotPlayer")
    }                                
}
*/
