using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ASlot : MonoBehaviour , IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        CardChangePosition(eventData);
    }

    protected abstract void CardChangePosition(PointerEventData eventData);

    protected void SwapCard(GameObject card)
    {
        Transform otherCard = transform.GetChild(0); 
        otherCard.SetParent(card.GetComponent<CardDragHandler>().originalParent); 
        otherCard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        card.transform.SetParent(transform);
        card.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    protected void CardGoesOn(GameObject card)
    {
        card.transform.SetParent(transform);
        card.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public abstract void OnBeginDrag(PointerEventData eventData);


    public abstract void RepairdCard(CardDragHandler card);

    public virtual void GetSlot()
    {
        Debug.Log("GetSlotASlot");
    }
    
    public abstract void DestroyCard(PointerEventData eventData);

}

/*


-si j'ai un objet Player avec des slots, les slots doivent avoir le script Slot ou SlotPlayer ?
*/




