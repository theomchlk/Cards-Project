using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardShop : AContainsSlots, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ShopSO shopSO;
    public TextMeshProUGUI textForSale;
    public TextMeshProUGUI textForWidgetGold;
    public int nbSlotShop;
    public int addSlotShopPrice;
    public float multiplicatorSlotShopPrice;
    public int gold;
    public int gainGoldIfWin;
    public int gainGoldIfLose;
    public List<ListCard> cardsAvailable;

    public void Awake()
    {
        addSlotShopPrice = shopSO._addSlotShopPrice;
        multiplicatorSlotShopPrice = shopSO._multiplicatorSlotShopPrice;
        gold = shopSO._startingGold;
        gainGoldIfWin = shopSO._gainGoldIfWin;
        gainGoldIfLose = shopSO._gainGoldIfLose;
        cardsAvailable = shopSO._cardsAvailable;
        
        
    }

    public void Start()
    {
        textForWidgetGold.text = gold.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
        {

            if (eventData.pointerDrag.GetComponent<CardDragHandler>().originalContainerSlot.GetComponent<AContainsSlots>().ContainsSlot(transform))
            {
                CardLogic card = eventData.pointerDrag.GetComponent<CardLogic>();
                transform.GetComponent<CanvasGroup>().alpha = 0.5f;
                textForSale.gameObject.SetActive(true);
                textForSale.text = card.value * card.percentageLessWhenRefund / 100 + " PO";

            }
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetComponent<CanvasGroup>().alpha = 1f;
        textForSale.gameObject.SetActive(false);
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            CardDragHandler cardDragged = eventData.pointerDrag.GetComponent<CardDragHandler>();
            if (cardDragged.originalContainerSlot.GetComponent<AContainsSlots>().ContainsSlot(transform))
            {
                Debug.Log(cardDragged.originalParent.GetComponent<SlotForShop>() != null);
                if (cardDragged.originalParent.GetComponent<SlotForShop>() == null)
                {
                    CardLogic card = eventData.pointerDrag.GetComponent<CardLogic>();
                    gold += ( card.value * card.percentageLessWhenRefund) / 100;
                    textForWidgetGold.text = gold.ToString();
                    Debug.Log(gold.GetType());
                    textForSale.gameObject.SetActive(false);
                    transform.GetComponent<CanvasGroup>().alpha = 1;
                    Debug.Log(gold);
                    cardDragged.originalParent.GetComponent<ACardSlot>().DestroyCard(eventData);
                }
            }
            

        }
    }
    

    public void Addgold(int amount)
    {
        gold += amount;
    }

    public void Subtractgold(int amount)
    {
        gold -= amount;
    }


    
}
