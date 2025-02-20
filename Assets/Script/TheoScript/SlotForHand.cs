using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotForHand : ASlot
{
    public bool occupied = false;
    protected override void CardChangePosition(GameObject card)
    {
        CardDragHandler cardDragged = card.GetComponent<CardDragHandler>();
        if (cardDragged.originalContainerSlot.GetComponent<IContainsSlots>().ContainsSlot(transform.parent))
        {
            if (cardDragged.originalParent.GetComponent<SlotForHand>() != null)
            {
                if (occupied == false)
                {   
                    cardDragged.originalParent.GetComponent<SlotForHand>().occupied = false;
                    CardGoesOn(card);
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
                        CardGoesOn(card);
                        occupied = true;
                        cardDragged.originalContainerSlot = transform.parent;
                    }
                    
                }
            }
        }
        
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        
        CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
        if (cardDragged.originalParentInRememberingTypeSlot != transform)
        {
            cardDragged.originalParentInRememberingTypeSlot = transform;
            transform.GetComponent<Image>().sprite = cardDragged.GetComponent<Image>().sprite;
            Debug.Log("EtLa?");
        }

        transform.GetComponent<CanvasGroup>().alpha = 0.5f;
    }

    public override void RepairdCard(CardDragHandler cardDragged)
    {

        cardDragged.originalParentInRememberingTypeSlot.GetComponent<CanvasGroup>().alpha = 1;
        cardDragged.transform.SetParent(cardDragged.originalParentInRememberingTypeSlot.transform);
        cardDragged.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        
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

Si j'ai un slot_1 avec comme script SlotPlayer, est ce que slot_1.GetComponent<Slot>().Fonc2(); fonctionne ?
et est ce que slot_1.GetComponent<Slot>().Fonc1() fonctionne ?                                  
*/
